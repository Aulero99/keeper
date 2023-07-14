namespace keeper.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;

        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }

        internal Vault Edit(Vault data)
        {
            Vault original = _repo.GetVaultById(data.Id);
            if(original.CreatorId != data.CreatorId) throw new Exception("Unauthorized: Cannot edit this keep.");

            data.Name = data.Name != null ? data.Name : original.Name;
            data.Description = data.Description != null ? data.Description : original.Description;
            data.Img = data.Img != null ? data.Img : original.Img;
            data.IsPrivate = data.IsPrivate != null ? data.IsPrivate : original.IsPrivate;

            return _repo.Edit(data);
        }

        internal Vault GetVaultById(int vaultId, string id)
        {
            Vault vault = _repo.GetVaultById(vaultId);
            if(vault.Name == null) throw new Exception($"No vault id:{vaultId} found.");
            if(vault.IsPrivate == true && vault.CreatorId != id) throw new Exception($"Vault id {vaultId} is private, and you do not have permission for access.");
            return vault;
        }

        internal Vault PostNewVault(Vault data)
        {
            return _repo.PostNewVault(data);
        }
    }
}