using FuteBet.Dominio.Commands.Command;
using FuteBet.Dominio.Commands.Request;
using FuteBet.Dominio.Commands.Response;
using System;

namespace ForteBet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //LoginUsuarioRequest loginUsuarioRequest = new LoginUsuarioRequest();
            //loginUsuarioRequest.Email = "jarson@gmail.com";
            //loginUsuarioRequest.Senha = "12345";

            //UsuarioCommandHandler usuarioCommand = new UsuarioCommandHandler();
            //LoginUsuarioResponse response =(LoginUsuarioResponse) usuarioCommand.Handler(loginUsuarioRequest);

            //Console.WriteLine("Acesso:"+response.Acesso);
            //Console.WriteLine("Token:"+response.Token);
            //Console.WriteLine();
            //Console.WriteLine("Notificações:");
            //foreach (var item in response.Notificacoes)
            //{
            //    Console.WriteLine(item.Property+"  -  "+item.Message);
            //}
          
            Console.ReadKey();
        }
    }
}
