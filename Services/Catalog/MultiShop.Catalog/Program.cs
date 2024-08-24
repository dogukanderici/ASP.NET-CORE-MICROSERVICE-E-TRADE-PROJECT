using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using MultiShop.Catalog.DataAccess.Abstract;
using MultiShop.Catalog.DataAccess.Concrete;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.ProductDetailService;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
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

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();

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
