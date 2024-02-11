1). Crear el proyecto 
    dotnet new console
2). Agregar los paquetes
    dotnet add package Microsoft.Extensions.Configuration.Json --version 8.0.0-preview.4.23259.5
    dotnet add package Microsoft.Extensions.Hosting --version 7.0.1
    dotnet add package MySql.Data --version 8.0.33
    dotnet add package Dapper --Version 2.0.123
3). Crear las carpetas
    Common
        Helpers
    Domain
        Entities
    Infrastructure
        Databases
        Repositories
4). Crear la Interfece de Operaicones Bd
        Infrastructure/Databases
            IConexionMySqlDapper.cs
5). Crear la clase de Operaciones a BD
        Infrastructure/Databases
            ConexionMySqlDapper.cs
5.1). Crear la conexion 
        IDbConnection con = new MySqlConnection(strinCon);
5.2). Opcional: Crear la BD y las tablas, etc
        var sql = $"CREATE DATABASE IF NOT EXIST {laBaseDatos}";
        await con.ExcuteAsync(sql);
6). Crear el appsettings.json
6.1). Agregar la cadena de conexion  
     "ConnectionStrings": {
        "ConexionMySQL": "Server=localhost;UserId=root;Password=root;Database=bd_net7"
    },
6.2). Opcionalmente se pueden pasar los parametros de conexion como objetos Json mapeados a una clase
    "DbSettings": {
        "Server": "localhost",
        "Database": "bd_net7",
        "UserId": "root",
        "Password": "root"
    }
8). Registrar el appsettins.json en le .csproj
     <ItemGroup>
        <Content Include="appsettings.json">
            <CopyToOutputDirectory>Always</CopyToOutputDirectory>
        </Content>
    </ItemGroup>
9). Obtener objeto de configuracion 
        var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables()
        .Build();

10). Obtener objeto de aplicacion y registrar la dependencias
    // ReadMe # 10
    var app = Host.CreateDefaultBuilder(args)
    .ConfigureServices(service =>
    {
        // Raadme #11
        service.Configure<DbSettings>(configuration.GetSection("DbSettings"));
        service.AddSingleton<ConexionMySqlDapper>();
        service.AddScoped<IConexionMySqlDapper, ConexionMySqlDapper>();
    })
    .Build();
11). Crear una clase de prueba
    Tests
        TestDapper.cs
12). Realizar las pruebas de conexion
    Program.cs
    await TestDapper.PruebaListarTodoAsync(configuration);
    var dbSettings = configuration.GetRequiredSection("DbSettings").Get<DbSettings>();
    await TestDapper.PruebaListarTodoV2Async(dbSettings);


