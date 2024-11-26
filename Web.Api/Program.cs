using Application;
using BookStoreInfrastructure;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Web.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));


builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddBearerToken();

builder.Services.AddIdentity<User, IdentityRole<int>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddApiEndpoints();


var connectionString = builder.Configuration.GetConnectionString("inversiondb");

builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseSqlServer(connectionString)
);

// Aplication 
builder.Services.AddAplication();

// Services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IOrdenRepository, OrdenRepository>();
builder.Services.AddScoped<IEstadoOrdenRepository, EstadoOrdenRepository>();
builder.Services.AddScoped<ITipoActivoRepository, TipoActivoRepository>();
builder.Services.AddScoped<IActivoRepository, ActivoRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


DatabaseInitilaizer.Seed(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapIdentityApi<User>();

app.MapControllers();

app.Run();


//Campo Tipo de dato Requerido Validación
//ID de la orden int SI N/A
//ID de la cuenta int SI N/A
//Nombre del activo string SI Largo máx 32
//caracteres
//Cantidad int SI mayor que 0
//Precio decimal SI mayor que 0
//Operación char SI ‘C’ para indicar
//Compra, ‘V’ para
//indicar Venta
//Estado int NO Ver Adicionales
//Monto Total decimal NO mayor que 0