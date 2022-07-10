using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebSubjectManagement.Models
{
    public class DBConnection
    {
        string conn;
        public DBConnection()
        {
            conn = ConfigurationManager.ConnectionStrings["QLMonHoc"].ConnectionString;

        }
        public SqlConnection getConn()
        {
            return new SqlConnection(conn);
        }

    }
}