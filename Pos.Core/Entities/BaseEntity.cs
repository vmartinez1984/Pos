using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Pos.Core.Entities
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [StringLength(50)]
        public string Id { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime DateRegistration { get; set; } = DateTime.Now;
    }
}