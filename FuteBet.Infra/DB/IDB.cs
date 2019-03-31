using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FuteBet.Infra.DB
{
    public interface IDB:IDisposable
    {
        IDbConnection GetDbConnection();

    }
}
