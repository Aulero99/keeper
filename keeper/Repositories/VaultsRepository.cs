namespace keeper.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;

        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Vault Edit(Vault data)
{
            string sql = @"
            UPDATE vaults
            SET
            name = @Name,
            description = @Description,
            img = @Img,
            isPrivate = @IsPrivate
            WHERE id = @Id
            ;";
            _db.Execute(sql, data);
            return data;
        }

        internal Vault GetVaultById(int vaultId)
        {
            string sql = @"
            SELECT 
            v.*, 
            a.*
            FROM vaults v 
            JOIN accounts a ON a.id = v.CreatorId
            WHERE v.id = @vaultId
            ;";
            
            return _db.Query<Vault, Profile, Vault>(sql,(v,p)=>{
                v.Creator = p;
                return v;
            }, new{vaultId}).FirstOrDefault();
        }

        internal Vault PostNewVault(Vault data)
        {
            string sql = @"
            INSERT INTO vaults
            (Name, Description, Img, CreatorId, IsPrivate)
            VALUES
            (@Name, @Description, @Img, @CreatorId, @IsPrivate);
            
            SELECT 
            v.*, 
            a.*
            FROM vaults v 
            JOIN accounts a ON a.id = v.CreatorId
            WHERE v.id = LAST_INSERT_ID()
            ;";

            return _db.Query<Vault, Profile, Vault>(sql, (v,p)=>{
                v.Creator = p;
                return v;
            }, data).FirstOrDefault();
        }
    }
}