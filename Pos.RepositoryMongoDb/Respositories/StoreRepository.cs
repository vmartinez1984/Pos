using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pos.Core.Entities;
using Pos.Core.Interfaces.IRepositories;
using Pos.RepositoryMongoDb.DataBaseSettings;

namespace Pos.RepositoryMongoDb.Respositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly IMongoCollection<StoreEntity> _collection;

        public StoreRepository(IOptions<PosDatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
           databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<StoreEntity>(
                databaseSettings.Value.StoreCollectionName);
        }

        public async Task<string> AddAsync(StoreEntity entity)
        {
            await _collection.InsertOneAsync(entity);

            return entity.Id;
        }

        public async Task<StoreEntity> GetAsync(string barcode)
        {
            StoreEntity entity;

            entity = await _collection.Find(x => x.Barcode == barcode && x.IsActive == true).FirstAsync();

            return entity;
        }

        public Task<List<StoreEntity>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task SubstractPieces(string barcode, int pieces)
        {
            StoreEntity entity;

            entity = await GetAsync(barcode);
            entity.Pieces = entity.Pieces - pieces;

            await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }
    }
}