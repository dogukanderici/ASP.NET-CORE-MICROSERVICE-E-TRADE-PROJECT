using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class OfferDiscount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OfferDiscountId { get; set; }
        public string OfferDiscountTitle { get; set; }
        public string OfferDiscountSubTitle { get; set; }
        public string OfferDiscountSubImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
