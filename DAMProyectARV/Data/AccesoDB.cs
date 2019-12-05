using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAMProyectARV.Data
{
    public class AccesoDB
    {
        public DataTable executeSqlQuery (string query)
        {
            SqlConnection oConn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString);
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Connection = oConn;
            oConn.Open();
            return dt;
        }
    }
}