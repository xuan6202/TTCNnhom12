using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS
{
    public class Connectionss
    {
        public SqlConnection connection;
        public string connectionString;

        public Connectionss(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void OpenConnection()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public bool IsConnectionOpen()
        {
            return connection != null && connection.State == System.Data.ConnectionState.Open;
        }

        public SqlCommand CreateCommand(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            return command;
        }
    }
}
