using System.Collections;
using App3_ConnBdMySQLDapper.Domain.Entities;

namespace App3_ConnBdMySQLDapper.Infrastructure.Repositories;
public interface IUsuarioRepository
{
    Task<IEnumerable<Usuario>> ListarTodoAsync();
    Task<Usuario> BuscarPorId(int id);
    Task<Usuario> BuscarPorEmail(string email);
    Task<IEnumerable<Usuario>> buscarPorNombre(string nombre);
    Task Insertar(Usuario u);
    Task Actaulizar(Usuario u);
    Task Eliminar(Usuario u);
}