using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTRKDotNetCore.ConsoleApp
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "LAPTOP-1PC0MA3L\\MSSQLSERVER2022",
            InitialCatalog = "DotNetTraningBatch4",
            UserID = "sa",
            Password = "sa@123"
        };
    }
}
