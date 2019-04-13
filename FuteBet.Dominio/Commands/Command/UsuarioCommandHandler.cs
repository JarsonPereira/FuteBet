using FluentValidator;
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
    public class UsuarioCommandHandler : ICommandHandler<LoginUsuarioRequest>,ICommandHandler<CadastroUsuarioRequest>
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
             LoginUsuarioResponse loginUsuarioRequest = new LoginUsuarioResponse() { Autenticado = false };

            if (!usuario.IsValid())
            {
                 return loginUsuarioRequest;
            }

            LoginUsuarioResult loginUsuario =  usuarioRepositorio.LoginUsuario(usuario);

            if (loginUsuario == null )
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
            loginUsuarioRequest.ID = loginUsuario.ID;
            loginUsuarioRequest.Email = loginUsuario.Email;
            loginUsuarioRequest.Nome = loginUsuario.Nome;

            return loginUsuarioRequest;
        }

        public IResponse Handler(CadastroUsuarioRequest request)
        {
              CadastroUsuarioResponse cadastroUsuarioRequest = new CadastroUsuarioResponse();
            Email email = new Email(request.Email);
            Senha senha = new Senha(request.Senha);
            Documento documento = new Documento(request.Documento);

            Usuario usuario = new Usuario(request.Nome,documento,email, senha,Status.Ativo);
            if (!usuario.IsValid())
            {
                cadastroUsuarioRequest.Cadastrado = false;
                cadastroUsuarioRequest.Notificacoes =(List<Notification>) usuario.Notifications;
                return cadastroUsuarioRequest;
            }

            bool salvo = usuarioRepositorio.SalvarUsuario(usuario);

            if (salvo)
            {
                 cadastroUsuarioRequest.Cadastrado = true;
              
                return cadastroUsuarioRequest;
            }
            else
            {
                 cadastroUsuarioRequest.Cadastrado = false;
                cadastroUsuarioRequest.Notificacoes =(List<Notification>) usuario.Notifications;
                return cadastroUsuarioRequest;
            }
           
        }
    }
}
