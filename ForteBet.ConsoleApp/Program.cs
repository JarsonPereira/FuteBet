using FuteBet.Dominio.Commands.Command;
using FuteBet.Dominio.Commands.Request;
using FuteBet.Dominio.Commands.Response;
using System;
using SimpleInjector;
using FuteBet.Infra.SGBD;
using FuteBet.Infra.DB;
using FuteBet.Dominio.Repositorio;
using FuteBet.Infra.Repositorio;

namespace ForteBet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Container container = new Container();
            container.Register<IDB, MSSqlServer>(Lifestyle.Singleton);
            container.Register<IUsuarioRepositorio, UsuarioRepositorio>();

            var conexao = container.GetInstance<IUsuarioRepositorio>();

            LoginUsuarioRequest loginUsuarioRequest = new LoginUsuarioRequest();
            loginUsuarioRequest.Email = "jarsono90@gmail.com";
            loginUsuarioRequest.Senha = "123456";

            UsuarioCommandHandler usuarioCommand = new UsuarioCommandHandler(conexao);
            LoginUsuarioResponse response = (LoginUsuarioResponse)usuarioCommand.Handler(loginUsuarioRequest);

            Console.ReadKey();
        }
    }
}
