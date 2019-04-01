using FuteBet.Infra.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FuteBet.Infra.SGBD
{
    public class MSSqlServer : IDB
    {
        private static SqlConnection GetSqlConnection;
        private  readonly string StringConexao;

        public MSSqlServer()
        {
            StringConexao = @"server=CDS-JARSON\SQLEXPRESS;database=Futebet;User Id=sa;Password=123;";
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GetSqlConnection.Close();
            GC.SuppressFinalize(this);
        }

        public  IDbConnection GetDbConnection()
        {
            if (GetSqlConnection == null)
            {
                return new SqlConnection(StringConexao);
            }
            else
            {
                return GetSqlConnection;
            }
        }
    }
}
