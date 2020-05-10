using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomApplication.Services.DAL
{
    public interface IConnectionFactory : IDisposable
    {
        IDbTransaction Transaction { get; }
        IDbConnection GetConnection(string connectionString);
    }

}
