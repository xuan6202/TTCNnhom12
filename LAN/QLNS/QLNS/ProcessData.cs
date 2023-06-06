using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS
{
    public class ProcessData
    {
        private Connectionss database;

        public ProcessData(Connectionss database)
        {
            this.database = database;
        }

        public void ExecuteNonQuery(string query)
        {
            SqlCommand command = database.CreateCommand(query);
            command.ExecuteNonQuery();
        }

        public DataTable ExecuteQuery(string query)
        {
            SqlCommand command = database.CreateCommand(query);
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            return dataTable;
        }
    }
}
