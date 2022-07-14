using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pos.Core.Entities;
using Pos.Core.Interfaces.IRepositories;
using Pos.RepositoryMongoDb.DataBaseSettings;

namespace Pos.RepositoryMongoDb.Respositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserEntity> _collection;

        public UserRepository(IOptions<PosDatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
           databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<UserEntity>(
                databaseSettings.Value.UsersCollectionName);
        }
        public async Task<string> AddAsync(UserEntity entity)
        {
            await _collection.InsertOneAsync(entity);

            return entity.Id;
        }

        public async Task<bool> ExistsEmailAsync(string email)
        {
            long count;

            count = await _collection.CountDocumentsAsync(x => x.Email == email && x.IsActive == true);

            return count == 0 ? false : true;
        }

        public async Task<List<UserEntity>> GetAsync()
        {
            List<UserEntity> entities;

            entities = await _collection.Find(_ => true).ToListAsync();

            return entities;
        }

        public async Task<UserEntity> GetAsync(string email)
        {
            UserEntity entity;

            entity = await _collection.Find(x => x.Email == email).FirstOrDefaultAsync();

            return entity;
        }
    }
}