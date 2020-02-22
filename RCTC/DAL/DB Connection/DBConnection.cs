using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCTC.DAL
{
    public class DBConnection
    {
        public DBConnection() { }

        public string ConnectionString = "Data Source= DESKTOP-KUM7RBC ;Initial Catalog=RCTC; Trusted_Connection=True";

        public SqlConnection Connect()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
