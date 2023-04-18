using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace AutoShkollaRona
{
    class lidhja
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-JR7UJM0\SQLEXPRESS;Initial Catalog=AutoShkollaRona;Integrated Security=True");
        public SqlConnection active()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
    }
}
