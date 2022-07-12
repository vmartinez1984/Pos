using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pos.Core.Entities;
using Pos.Core.Interfaces.IRepositories;
using Pos.RepositoryMongoDb.DataBaseSettings;

namespace Pos.RepositoryMongoDb.Respositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IMongoCollection<RoleEntity> _collection;

        public RoleRepository(
            IOptions<PosDatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
           databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<RoleEntity>(
                databaseSettings.Value.RolesCollectionName);
        }

        public async Task<List<RoleEntity>> GetAsync()
        {
            List<RoleEntity> entities;

            entities = await _collection.Find(_ => true).ToListAsync();

            return entities;
        }

        public async Task<bool> ExistAsync(string name)
        {
            RoleEntity entities;

            entities = await _collection.Find(x => x.Name == name).FirstOrDefaultAsync();

            return entities is null ? false : true;
        }

        public async Task<string> GetNameAsync(string roleId)
        {
            string name;

            name = (await _collection.Find(x => x.Id == roleId)
            //.Select(x => x.Name)
            .FirstOrDefaultAsync()).Name;

            return  name;
        }
    }
}