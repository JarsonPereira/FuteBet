using FuteBet.Dominio.Commands.Request;
using FuteBet.Dominio.Commands.Response;
using FuteBet.Dominio.Entidade;
using FuteBet.Dominio.Enum;
using FuteBet.Dominio.Queries;
using FuteBet.Dominio.Repositorio;
using FuteBet.Dominio.ValuesObjects;
using FuteBet.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuteBet.Dominio.Commands.Command
{
    public class UsuarioCommandHandler : ICommandHandler<LoginUsuarioRequest>
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;

        public UsuarioCommandHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
        }

        public IResponse Handler(LoginUsuarioRequest request)
        {
            Email email = new Email(request.Email);
            Senha senha = new Senha(request.Senha);
            Usuario usuario = new Usuario(email, senha);

            LoginUsuarioResult loginUsuario =  usuarioRepositorio.LoginUsuario(usuario);

            LoginUsuarioResponse loginUsuarioRequest = new LoginUsuarioResponse() { Autenticado = false };

            if (loginUsuario == null)
            {
                 return loginUsuarioRequest;
            }
            if(((Status)loginUsuario.Status != Status.Ativo))
            {
                return loginUsuarioRequest;
            }

            loginUsuarioRequest.Autenticado = true;
            loginUsuarioRequest.DataInicio = DateTime.Now;
            loginUsuarioRequest.DataExpiracao = loginUsuarioRequest.DataInicio.AddMinutes(15);
            loginUsuarioRequest.Token = loginUsuario.Token;


            return loginUsuarioRequest;
        }
    }
}
