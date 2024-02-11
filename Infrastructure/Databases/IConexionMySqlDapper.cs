using System.Data;
namespace  App3_ConnBdMySQLDapper.Infrastructure.Databases;
public interface IConexionMySqlDapper{
    public IDbConnection Conectar();

}