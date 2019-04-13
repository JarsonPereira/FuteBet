using FuteBet.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuteBet.Dominio.Commands.Request
{
     public  class CadastroUsuarioRequest:IRequest
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get;  set; }
        public string Senha { get; set; }
    }
}
