using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Pos.Api.Controllers;
using Pos.Api.Services;
using Pos.BusinessLayer;
using Pos.Core.Interfaces.IBusinesLayer;
using Pos.Core.Interfaces.IRepositories;
using Pos.Core.Mappers;
using Pos.RepositoryMongoDb.DataBaseSettings;
using Pos.RepositoryMongoDb.Respositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddScoped<IAuthService,AuthService>();
builder.Services.Configure<PosDatabaseSettings>(builder.Configuration.GetSection("PosDatabase"));
//builder.Services.Configure<Jwt>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IRepository, RepositoryMongoDb>();
builder.Services.AddScoped<IUserBl, UserBl>();
builder.Services.AddScoped<IStoreBl, StoreBl>();
builder.Services.AddScoped<ISaleBl, SaleBl>();
builder.Services.AddScoped<IRoleBl, RoleBl>();
builder.Services.AddScoped<IProductBl, ProductBl>();
builder.Services.AddScoped<IUnitOfWorkBl, UnitOfWorkBl>();
var mapperConfig = new MapperConfiguration(mapperConfig =>
{
    mapperConfig.AddProfile<MapperImplements>();
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "Peticionario",
        ValidAudience = "Public",
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("G3VF4C6KFV43JH6GKCDFGJH45V36JHGV3H4C6F3GJC63HG45GH6V345GHHJ4623FJL3HCVMO1P23PZ07W8")
        )
    };
});

var app = builder.Build();
//Configurando la aplicación para JWT
app.UseAuthentication();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
