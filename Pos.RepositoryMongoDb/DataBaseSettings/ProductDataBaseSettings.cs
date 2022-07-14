namespace Pos.RepositoryMongoDb.DataBaseSettings
{
    public class PosDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string UsersCollectionName { get; set; } = null!;

        public string RolesCollectionName { get; set; } = null!;
        
        public string ProductsCollectionName { get; set; } = null!;

        public string StoreCollectionName { get; set; } = null!;
        
        public string SalesCollectionName { get; set; } = null!;
    }
}