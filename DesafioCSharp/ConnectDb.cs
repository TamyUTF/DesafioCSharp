using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp
{
    public class ConnectDb
    {
        public SqlConnection Db { get; private set; }
        public SqlConnection DbConnect()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=FORLOGIC296;Initial Catalog=DesafioCSharp;Persist Security Info=True;
                                                                User ID=sa;Password=123abc;Pooling=False");
            try
            {
                connection.Open();
                return  connection;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
                throw ex;
            }
        }

    }
}
