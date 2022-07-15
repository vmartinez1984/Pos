using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Pos.Core.Entities
{
    public class ProductEntity : ProductSaleEntity
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public decimal Cost { get; set; }

        public string UserId { get; set; }

         public bool IsActive { get; set; } = true;

        public DateTime DateRegistration { get; set; } = DateTime.Now;
    }

    public class ProductSaleEntity
    {
        public decimal Price { get; set; }

        public string Barcode { get; set; }

        public string Name { get; set; }
    }
}