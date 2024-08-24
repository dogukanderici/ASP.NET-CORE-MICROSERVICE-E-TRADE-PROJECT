using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Core.DataAccess.Abstract;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings.Abstract;
using MultiShop.Catalog.Settings.Concrete;
using System.Linq.Expressions;

namespace MultiShop.Catalog.Core.DataAccess.Concrete
{
    public class MongoRepositoryBase<TEntity, TResult, TCreate, TUpdate, TGet> : IRepositoryBase<TEntity, TResult, TCreate, TUpdate, TGet>
        where TEntity : class, new()
        where TResult : class, new()
        where TCreate : class, new()
        where TUpdate : class, new()
        where TGet : class, new()
    {
        private readonly IMongoCollection<TEntity> _mongoCollection;
        private readonly IMapper _mapper;
        private readonly IConfiguration Configuration;
        private CollectionNameSettings _collectionNameSettings;

        public MongoRepositoryBase(IMapper mapper, IDatabaseSettings databaseSettings, IConfiguration configuration, string collectionName)
        {

            Configuration = configuration;

            _collectionNameSettings = Configuration.GetSection(collectionName).Get<CollectionNameSettings>();

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _mongoCollection = database.GetCollection<TEntity>(_collectionNameSettings.CollectionName);

            _mapper = mapper;
        }

        public async Task CreateData(TCreate entity)
        {
            var value = _mapper.Map<TEntity>(entity);

            await _mongoCollection.InsertOneAsync(value);
        }

        public async Task DeleteData(Expression<Func<TEntity, bool>> filter = null)
        {
            await _mongoCollection.DeleteOneAsync(filter);
        }

        public async Task<List<TResult>> GetAllDataAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var values = (filter != null ? await _mongoCollection.Find<TEntity>(filter).ToListAsync() : await _mongoCollection.Find<TEntity>(x => true).ToListAsync());

            return _mapper.Map<List<TResult>>(values);
        }

        public async Task<TGet> GetDataAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var value = await _mongoCollection.Find<TEntity>(filter).FirstOrDefaultAsync();

            return _mapper.Map<TGet>(value);
        }

        public async Task UpdateData(Expression<Func<TEntity, bool>> filter, TUpdate entity)
        {
            var values = _mapper.Map<TEntity>(entity);

            await _mongoCollection.FindOneAndReplaceAsync(filter, values);
        }
    }
}
