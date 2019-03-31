using FuteBet.Dominio.Commands.Request;
using FuteBet.Dominio.Queries;
using FuteBet.Dominio.Repositorio;
using FuteBet.Infra.DB;
using Dapper;
using FuteBet.Dominio.Entidade;

namespace FuteBet.Infra.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private IDB GetDB;

        public UsuarioRepositorio(IDB getDB)
        {
            GetDB = getDB;
        }

        public LoginUsuarioResult LoginUsuario(Usuario loginUsuario)
        {
            string query = "Select ID,NOME,STATUS from Usuario where email = @EMAIL and senha=@SENHA";
           using(var con = GetDB.GetDbConnection())
            {
                return con.QueryFirstOrDefault<LoginUsuarioResult>(query, new { EMAIL = loginUsuario.Email.Endereco, SENHA = loginUsuario.Senha.SenhaForte });
            }
        }
    }
}
