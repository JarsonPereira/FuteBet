using FuteBet.Dominio.Commands.Request;
using FuteBet.Dominio.Entidade;
using FuteBet.Dominio.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuteBet.Dominio.Repositorio
{
    public interface IUsuarioRepositorio
    {
        LoginUsuarioResult LoginUsuario(Usuario loginUsuario);
    }
}
