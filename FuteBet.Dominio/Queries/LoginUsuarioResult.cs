using System;
using System.Collections.Generic;
using System.Text;

namespace FuteBet.Dominio.Queries
{
    public class LoginUsuarioResult
    {
         public Guid ID { get;  set; }
        public string Nome { get; set; }
        public int Status { get; set; }
        public string Token { get; set; }

    }
}
