using System;
using System.Collections.Generic;
using System.Text;

namespace FuteBet.Dominio.Entidade
{
   public  class TokenConfiguracoes
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}
