using FuteBet.Dominio.Commands.Request;
using FuteBet.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuteBet.Dominio.Commands.Command
{
    public class UsuarioCommandHandler : ICommandHandler<LoginUsuarioRequest>
    {
        public IResponse Handler(LoginUsuarioRequest request)
        {
            //01 Intancia Jogador
            //02 Busca Jogador no Banco
            //03 Verifica Status do jogador
            throw new NotImplementedException();
        }
    }
}
