using App3_ConnBdMySQLDapper.Common.Helpers;
using App3_ConnBdMySQLDapper.Infrastructure.Databases;
using App3_ConnBdMySQLDapper.Infrastructure.Repositories;
using App3_ConnBdMySQLDapper.Tests;
using Microsoft.Extensions.Configuration;
// Readme # 11
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Readme # 9
var configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json")
.AddEnvironmentVariables()
.Build();

// ReadMe # 10
var app = Host.CreateDefaultBuilder(args)
.ConfigureServices(service =>
{
    // Raadme #11
    service.Configure<DbSettings>(configuration.GetSection("DbSettings"));
    service.AddSingleton<ConexionMySqlDapper>();
    service.AddScoped<IConexionMySqlDapper, ConexionMySqlDapper>();
    service.AddScoped<IUsuarioRepository, UsuarioRepository>();
})
.Build();

await TestDapper.PruebaListarTodoAsync(configuration);
var dbSettings = configuration.GetRequiredSection("DbSettings").Get<DbSettings>();
await TestDapper.PruebaListarTodoV2Async(dbSettings);


app.RunAsync();
