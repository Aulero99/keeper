namespace keeper.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;

        public VaultKeepsService(VaultKeepsRepository repo)
        {
            _repo = repo;
        }

        internal VaultKeep Post(VaultKeep data)
        {
            // TODO users can currently make keeps for other users vaults
            // fix that
            return _repo.Post(data);
        }
    }
}