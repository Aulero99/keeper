namespace keeper.Models
{
    public class VaultBase
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public bool? IsPrivate { get; set; }

    }

    public class Vault : VaultBase
    {
        public Profile Creator { get; set; }
    }
}