using FluentValidator;
using FuteBet.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuteBet.Dominio.Commands.Response
{
    public class LoginUsuarioResponse:IResponse
    {

        public bool Acesso { get; set; }
        public string Token { get;  set; }
        public List<Notification> Notificacoes { get;  set; }
      
    }
}
