using App3_ConnBdMySQLDapper.Domain.Entities;
using App3_ConnBdMySQLDapper.Infrastructure.Databases;
using Dapper;

namespace App3_ConnBdMySQLDapper.Infrastructure.Repositories;
public class UsuarioRepository : IUsuarioRepository
{

    
   private ConexionMySqlDapper _conexion;

    public UsuarioRepository( ConexionMySqlDapper conexion)
    {
        _conexion = conexion;
    }

    public Task Actaulizar(Usuario u)
    {
        throw new NotImplementedException();
    }

    public Task<Usuario> BuscarPorEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<Usuario> BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Usuario>> buscarPorNombre(string nombre)
    {
        throw new NotImplementedException();
    }

    public Task Eliminar(Usuario u)
    {
        throw new NotImplementedException();
    }

    public Task Insertar(Usuario u)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Usuario>> ListarTodoAsync()
    {
        var sql = "SELECT * FROM Usuarios";
        using var conBd =  _conexion.Conectar();
        return await conBd.QueryAsync<Usuario>(sql);
    }
}