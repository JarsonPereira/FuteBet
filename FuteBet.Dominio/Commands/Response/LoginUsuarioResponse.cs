using FluentValidator;
using FuteBet.Dominio.Queries;
using FuteBet.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuteBet.Dominio.Commands.Response
{
    public class LoginUsuarioResponse:IResponse
    {
        public bool Autenticado { get; set; }
        public string Token { get;  set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataExpiracao { get; set; }

      
    }
}
