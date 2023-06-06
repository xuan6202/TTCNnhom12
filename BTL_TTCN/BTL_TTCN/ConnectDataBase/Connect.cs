using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BTL_TTCN.ConnectDatabase
{
    class Connect
    {
        private static string sConnect = @"Data Source = .\SQLEXPRESS ; Initial Catalog = BTL_TTCN; Integrated Security = True  ";
        private static SqlConnection con = null;
        public Connect()
        {
            OpenConnect();
        }

        private static void OpenConnect()
        {
            con = new SqlConnection(sConnect);
            con.Open();
            if(con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
        public static DataTable DataTransport (string sSQL)
        {
            OpenConnect();
            SqlDataAdapter adapter = new SqlDataAdapter(sSQL, con);
            DataTable dtData = new DataTable();
            dtData.Clear();
            adapter.Fill(dtData);
            return dtData;
        }
        public static int DataExecution(string sSQL)
        {
            int iResult = 0;
            OpenConnect();
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSQL;
            iResult = cmd.ExecuteNonQuery();
            return iResult;
        }
    }
}