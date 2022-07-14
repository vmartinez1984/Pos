using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pos.Core;
using Pos.Core.Entities;
using Pos.Core.Interfaces.IRepositories;
using Pos.RepositoryMongoDb.DataBaseSettings;

namespace Pos.RepositoryMongoDb.Respositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly IMongoCollection<SaleEntity> _collection;

        public SaleRepository(IOptions<PosDatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
           databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<SaleEntity>(
                databaseSettings.Value.SalesCollectionName);
        }

        public Task<string> AddAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}