using System.Data;
using App3_ConnBdMySQLDapper.Common.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace App3_ConnBdMySQLDapper.Infrastructure.Databases;

public class ConexionMySqlDapper : IConexionMySqlDapper
{

    private IDbConnection _conexion;
    private IConfiguration _configuration;
    private DbSettings _dbSettings;

    public ConexionMySqlDapper(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public ConexionMySqlDapper(IOptions<DbSettings> dbSettings)
    {
        _dbSettings = dbSettings.Value;
    }


    public ConexionMySqlDapper(DbSettings dbSettings)
    {
        _dbSettings = dbSettings;
    }
    public IDbConnection Connection
    {
        get => _conexion;

    }
    public IDbConnection Conectar()
    {
        string stringConn = _configuration.GetConnectionString("ConexionMySql");
        if ((stringConn == null || stringConn.Trim().Count() == 0) && _dbSettings == null)
        {
            throw new Exception("Parametros de conexion incorrectos");
        }
        else if(_dbSettings != null ){
            stringConn = $"server={_dbSettings.Server};uid={_dbSettings.UserId};password={_dbSettings.Password};database={_dbSettings.Database};";
        }
        try
        {
            return _conexion = new MySqlConnection(stringConn);
        }
        catch (System.Exception er)
        {
            System.Console.WriteLine("----- ERROR AL CORECTAR CON LA BD ---- ");
            System.Console.WriteLine("MENSAJE: " + er.Message);
            throw new Exception("Error al conectar con la BD\nMENSAJE: " + er.Message);
        }
    }
}