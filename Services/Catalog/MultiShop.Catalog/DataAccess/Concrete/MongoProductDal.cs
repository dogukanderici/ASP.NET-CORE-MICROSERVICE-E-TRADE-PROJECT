using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Catalog.Core.DataAccess.Concrete;
using MultiShop.Catalog.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings.Abstract;

namespace MultiShop.Catalog.DataAccess.Concrete
{
    public class MongoProductDal : MongoRepositoryBase<Product, ResultProductDto, CreateProductDto, UpdateProductDto, GetByIdProductDto>, IProductDal
    {
        public MongoProductDal(IMapper mapper, IDatabaseSettings databaseSettings, IConfiguration configuration, string collectionName) : base(mapper, databaseSettings, configuration, collectionName)
        {
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$group",new BsonDocument()
                {
                    {"_id",BsonNull.Value },
                    {"averagePrice",new BsonDocument("$avg","$ProductPrice") }
                })
            };

            //var result = await _mongoCollection.AggregateAsync<BsonDocument>(pipeline);
            //var price = result.FirstOrDefault().GetValue("averagePrice", decimal.Zero).AsDecimal;

            try
            {
                var resultCursor = await _mongoCollection.AggregateAsync<BsonDocument>(pipeline);
                var resultList = await resultCursor.ToListAsync();

                var firstResult = resultList.FirstOrDefault();

                if (firstResult == null)
                {
                    return decimal.Zero;
                }

                var priceBsonValue = firstResult.GetValue("averagePrice", BsonDecimal128.Create(decimal.Zero));

                var price = priceBsonValue.AsDecimal;

                return price;
            }
            catch (Exception ex)
            {
                // Hata mesajını logla veya incele
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }

            //return price;
        }
    }
}
