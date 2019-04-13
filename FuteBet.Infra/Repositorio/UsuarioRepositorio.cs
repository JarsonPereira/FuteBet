using FuteBet.Dominio.Commands.Request;
using FuteBet.Dominio.Queries;
using FuteBet.Dominio.Repositorio;
using FuteBet.Infra.DB;
using Dapper;
using FuteBet.Dominio.Entidade;
using System;

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
            string query = "Select ID,Nome,Email,Status   from Usuario where email = @EMAIL and senha=@SENHA";
           using(var con = GetDB.GetDbConnection())
            {
                return con.QueryFirstOrDefault<LoginUsuarioResult>(query, new { EMAIL = loginUsuario.Email.Endereco, SENHA = loginUsuario.Senha.SenhaForte });
            }
        }

        public bool SalvarUsuario(Usuario usuario)
        {
            string query = "INSERT INTO USUARIO(NOME,DOCUMENTO,EMAIL,SENHA,STATUS) VALUES (@Nome,@Documento,@Email,@Senha,@Status)";
            int status = (int)usuario.Status;
             using(var con = GetDB.GetDbConnection())
            {
                return con.Execute(query, new
                {
                    Nome=usuario.Nome,
                    Documento= usuario.Documento.CPF,
                    Email = usuario.Email.Endereco,
                    Senha= usuario.Senha.SenhaForte,
                   Status=status
                })>0?true:false;
            }
        }
    }
}
