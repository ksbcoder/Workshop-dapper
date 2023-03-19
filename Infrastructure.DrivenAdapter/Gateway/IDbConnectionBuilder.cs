using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DrivenAdapter.Gateway
{
    public interface IDbConnectionBuilder
    {
        Task<IDbConnection> CreateConnectionAsync();
    }
}
