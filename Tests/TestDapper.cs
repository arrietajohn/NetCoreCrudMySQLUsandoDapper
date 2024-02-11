using App3_ConnBdMySQLDapper.Common.Helpers;
using App3_ConnBdMySQLDapper.Domain.Entities;
using App3_ConnBdMySQLDapper.Infrastructure.Databases;
using App3_ConnBdMySQLDapper.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace App3_ConnBdMySQLDapper.Tests;

public class TestDapper
{


    public static async Task PruebaListarTodoAsync(IConfiguration configuration)
    {
        var conDd = new ConexionMySqlDapper(configuration);

        var repository = new UsuarioRepository(conDd);
        List<Usuario> usuarios = (List<Usuario>)await repository.ListarTodoAsync();
        System.Console.WriteLine("----- USUARIOS -----");
        foreach (Usuario u in usuarios)
        {
            System.Console.WriteLine($"USUARIO #{usuarios.IndexOf(u) + 1}");
            System.Console.WriteLine("ID: " + u.Id.ToString());
            System.Console.WriteLine("CLAVE: " + u.Clave);
            System.Console.WriteLine("NOMBRE: " + u.Nombre);
            System.Console.WriteLine("EMAIL: " + u.Email);
            System.Console.WriteLine("-------------------");
        }
    }

    public static async Task PruebaListarTodoV2Async(DbSettings dbSettings)
    {

        var conDd = new ConexionMySqlDapper(dbSettings);

        var repository = new UsuarioRepository(conDd);
        List<Usuario> usuarios = (List<Usuario>)await repository.ListarTodoAsync();
        System.Console.WriteLine("----- USUARIOS -----");
        foreach (Usuario u in usuarios)
        {
            System.Console.WriteLine($"USUARIO #{usuarios.IndexOf(u) + 1}");
            System.Console.WriteLine("ID: " + u.Id.ToString());
            System.Console.WriteLine("CLAVE: " + u.Clave);
            System.Console.WriteLine("NOMBRE: " + u.Nombre);
            System.Console.WriteLine("EMAIL: " + u.Email);
            System.Console.WriteLine("-------------------");
        }
    }
}

