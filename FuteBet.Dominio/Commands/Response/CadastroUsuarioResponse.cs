using FluentValidator;
using FuteBet.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuteBet.Dominio.Commands.Response
{
    public class CadastroUsuarioResponse:IResponse
    {
        public bool Cadastrado { get; set; }
        public List<Notification> Notificacoes { get; set; }
    }
}
