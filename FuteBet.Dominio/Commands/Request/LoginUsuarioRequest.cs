using FuteBet.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuteBet.Dominio.Commands.Request
{
   public  class LoginUsuarioRequest:IRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
