using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Pos.Core.Entities
{
    public class RoleEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [StringLength(50)]
        public string Id { get; set; }
        
        public string Name { get; set; }
    }
}