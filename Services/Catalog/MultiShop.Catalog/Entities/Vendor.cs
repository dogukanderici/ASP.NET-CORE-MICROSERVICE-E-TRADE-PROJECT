using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Vendor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public string VendorImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
