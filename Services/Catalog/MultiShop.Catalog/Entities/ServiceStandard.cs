using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class ServiceStandard
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ServiceStandardId { get; set; }
        public string ServiceStandardName { get; set; }
        public string ServiceStandardIcon { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
