using CouchDB.Driver.DependencyInjection;
using HappyPlants.Common.Interfaces.Services;
using HappyPlants.Data;
using HappyPlants.Data.DBObjects;
using HappyPlants.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPlantService, PlantService>();
builder.Services.AddScoped<IPlantRepository, PlantRepository>();
builder.Services.AddCouchContext<HappyPlantContext>(builder =>
{
    builder
    .UseEndpoint("http://192.168.1.90:5984")
    .UseBasicAuthentication("test", "test")
    .EnsureDatabaseExists();

});

var autoMapperAssemblies = new List<Assembly>() { typeof(PlantDocument).Assembly };

builder.Services.AddAutoMapper(autoMapperAssemblies);
var app = builder.Build();

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
