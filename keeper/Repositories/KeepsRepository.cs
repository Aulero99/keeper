namespace keeper.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal int Delete(int keepId)
        {
            string sql = @"
            DELETE FROM keeps
            WHERE id = @keepId
            LIMIT 1
            ;";
            int rows = _db.Execute(sql, new{keepId});
            return rows;
        }

        internal Keep Edit(Keep data)
        {
            string sql = @"
            UPDATE keeps
            SET
            name = @Name,
            description = @Description,
            img = @Img,
            views = @Views 
            WHERE id = @Id
            ;";
            _db.Execute(sql, data);
            return data;
        }

        internal List<Keep> GetAll()
        {
            string sql = @"
            SELECT 
            k.*, 
            a.*,
            COUNT(v.id) AS Kept
            FROM keeps k 
            JOIN accounts a ON a.id = k.CreatorId
            LEFT JOIN vaultKeeps v ON v.keepId = k.id
            GROUP BY (k.id)
            ;";
            
            return _db.Query<Keep, Profile, Keep>(sql,(k,p)=>{
                k.Creator = p;
                return k;
            }).ToList();
        }

        internal Keep GetKeepById(int Id)
        {
            string sql = @"
            SELECT 
            k.*, 
            a.*,
            COUNT(v.id) AS Kept
            FROM keeps k 
            JOIN accounts a ON a.id = k.CreatorId
            LEFT JOIN vaultKeeps v ON v.keepId = k.id
            WHERE k.id = @Id
            ;";
            
            return _db.Query<Keep, Profile, Keep>(sql,(k,p)=>{
                k.Creator = p;
                return k;
            }, new{Id}).FirstOrDefault();
        }

        internal Keep PostNewKeep(Keep data)
        {
            string sql = @"
            INSERT INTO keeps
            (Name, Description, Img, CreatorId)
            VALUES
            (@Name, @Description, @Img, @CreatorId);
            
            SELECT 
            k.*, 
            a.*,
            COUNT(v.id) AS Kept
            FROM keeps k 
            JOIN accounts a ON a.id = k.CreatorId
            LEFT JOIN vaultKeeps v ON v.keepId = k.id
            WHERE k.id = LAST_INSERT_ID()
            ;";

            return _db.Query<Keep, Profile, Keep>(sql, (k,p)=>{
                k.Creator = p;
                return k;
            }, data).FirstOrDefault();
        }
    }
}