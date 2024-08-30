using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using MultiShop.Catalog.DataAccess.Abstract;
using MultiShop.Catalog.DataAccess.Concrete;
using MultiShop.Catalog.Services.AboutServices;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.FeatureSliderService;
using MultiShop.Catalog.Services.OfferDiscountServices;
using MultiShop.Catalog.Services.ProductDetailService;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Services.ServiceStandardServices;
using MultiShop.Catalog.Services.SpecialOfferServices;
using MultiShop.Catalog.Services.VendorServices;
using MultiShop.Catalog.Settings.Abstract;
using MultiShop.Catalog.Settings.Concrete;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Categories Api'si için JwtTBearer tanýmlamalarý yapýlýr.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    opt =>
    {
        // JwtBearer'ý kiminle (URL) birlikte kullanýlacaðýný belirler.
        // Identity Server'ýn ayaða kalktýðý URL
        opt.Authority = builder.Configuration["IdentityServerUrl"];

        // IdentityServer Config dosyasýndaki ApiResource ile tanýmlanan yer
        opt.Audience = "ResourceCatalog";

        // URL https yerine http ile yazýldýðý için eklendi.
        opt.RequireHttpsMetadata = false;
    });

builder.Services.AddScoped<ICategoryDal, MongoCategoryDal>(sp =>
{
    var mapper = sp.GetRequiredService<IMapper>();
    var databaseSettings = sp.GetRequiredService<IDatabaseSettings>();
    var configuration = sp.GetRequiredService<IConfiguration>();
    string collectionName = "CategoryCollectionSettings";

    return new MongoCategoryDal(mapper, databaseSettings, configuration, collectionName);
});

builder.Services.AddScoped<IProductDal, MongoProductDal>(sp =>
{
    var mapper = sp.GetRequiredService<IMapper>();
    var databaseSettings = sp.GetRequiredService<IDatabaseSettings>();
    var configuration = sp.GetRequiredService<IConfiguration>();
    string collectionName = "ProductCollectionSettings";

    return new MongoProductDal(mapper, databaseSettings, configuration, collectionName);
});

builder.Services.AddScoped<IProductDetailDal, MongoProductDetailDal>(sp =>
{
    var mapper = sp.GetRequiredService<IMapper>();
    var databaseSettings = sp.GetRequiredService<IDatabaseSettings>();
    var configuration = sp.GetRequiredService<IConfiguration>();
    string collectionName = "ProductDetailCollectioSettings";

    return new MongoProductDetailDal(mapper, databaseSettings, configuration, collectionName);
});

builder.Services.AddScoped<IProductImageDal, MongoProductImageDal>(sp =>
{
    var mapper = sp.GetRequiredService<IMapper>();
    var databaseSettings = sp.GetRequiredService<IDatabaseSettings>();
    var configuration = sp.GetRequiredService<IConfiguration>();
    string collectionName = "ProductImageCollectionSettings";

    return new MongoProductImageDal(mapper, databaseSettings, configuration, collectionName);
});

builder.Services.AddScoped<IFeatureSliderDal, MongoFeatureSliderDal>(sp =>
{
    var mapper = sp.GetRequiredService<IMapper>();
    var databaseSettings = sp.GetRequiredService<IDatabaseSettings>();
    var configuration = sp.GetRequiredService<IConfiguration>();
    string collectionName = "FeatureSliderCollectionSettings";

    return new MongoFeatureSliderDal(mapper, databaseSettings, configuration, collectionName);
});

builder.Services.AddScoped<ISpecialOfferDal, MongoSpecialOfferDal>(sp =>
{
    var mapper = sp.GetRequiredService<IMapper>();
    var databaseSettings = sp.GetRequiredService<IDatabaseSettings>();
    var configuration = sp.GetRequiredService<IConfiguration>();
    string collectionName = "SpecialOfferCollectionSettings";

    return new MongoSpecialOfferDal(mapper, databaseSettings, configuration, collectionName);
});

builder.Services.AddScoped<IServiceStandardDal, MongoServiceStandardDal>(sp =>
{
    var mapper = sp.GetRequiredService<IMapper>();
    var databaseSettings = sp.GetRequiredService<IDatabaseSettings>();
    var configuration = sp.GetRequiredService<IConfiguration>();
    string collectionName = "ServiceStandardCollectionSettings";

    return new MongoServiceStandardDal(mapper, databaseSettings, configuration, collectionName);
});

builder.Services.AddScoped<IOfferDiscountDal, MongoOfferDiscountDal>(sp =>
{
    var mapper = sp.GetRequiredService<IMapper>();
    var databaseSettings = sp.GetRequiredService<IDatabaseSettings>();
    var configuration = sp.GetRequiredService<IConfiguration>();
    string collectionName = "OfferDiscountCollectionSettings";

    return new MongoOfferDiscountDal(mapper, databaseSettings, configuration, collectionName);
});

builder.Services.AddScoped<IVendorDal, MongoVendorDal>(sp =>
{
    var mapper = sp.GetRequiredService<IMapper>();
    var databaseSettings = sp.GetRequiredService<IDatabaseSettings>();
    var configuration = sp.GetRequiredService<IConfiguration>();
    string collectionName = "VendorCollectionSettings";

    return new MongoVendorDal(mapper, databaseSettings, configuration, collectionName);
});

builder.Services.AddScoped<IAboutDal, MongoAboutDal>(sp =>
{
    var mapper = sp.GetRequiredService<IMapper>();
    var databaseSettings = sp.GetRequiredService<IDatabaseSettings>();
    var configuration = sp.GetRequiredService<IConfiguration>();
    string collectionName = "AboutCollectionSettings";

    return new MongoAboutDal(mapper, databaseSettings, configuration, collectionName);
});

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IFeatureSliderService, FeatureSliderService>();
builder.Services.AddScoped<ISpecialOfferService, SpecialOfferService>();
builder.Services.AddScoped<IServiceStandardService, ServiceStandardService>();
builder.Services.AddScoped<IOfferDiscountService, OfferDiscountService>();
builder.Services.AddScoped<IVendorService, VendorService>();
builder.Services.AddScoped<IAboutService, AboutService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
