namespace keeper.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;
        private readonly KeepsRepository _krepo;

        public VaultKeepsRepository(IDbConnection db, KeepsRepository krepo)
        {
            _db = db;
            _krepo = krepo;
        }

        internal VaultKeep Post(VaultKeep data)
        {
            string sql = @"
            INSERT INTO vaultKeeps
            (CreatorId, VaultId, KeepId)
            VALUES
            (@CreatorId, @VaultId, @KeepId);
            
            SELECT 
            vk.*, 
            a.*,
            v.*,
            k.*
            FROM vaultKeeps vk 
            JOIN accounts a ON a.id = vk.CreatorId
            JOIN vaults v ON v.id = vk.VaultId
            JOIN keeps k ON k.id = vk.KeepId
            WHERE vk.id = LAST_INSERT_ID()
            ;";

            VaultKeep vk = _db.Query<VaultKeep, Profile, Vault, Keep, VaultKeep>(sql, (vk,p,v,k)=>{
                vk.Creator = p;
                vk.Keep = k;
                vk.Vault = v;
                vk.Vault.Creator = p;
                vk.Keep.Creator = p;
                return vk;
            }, data).FirstOrDefault();
            vk.Keep = _krepo.GetKeepById(vk.KeepId);
            return vk;
        }
    }
}