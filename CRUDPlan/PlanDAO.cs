using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp
{
    class PlanDAO
    {
        public SqlConnection sql = new ConnectDb().DbConnect();
        public SqlCommand command = new SqlCommand();
        public bool InsertPlan(Plan plan)
        {
            command.Connection = sql;
            command.CommandText = @"INSERT INTO USERS (NAME, STARTDATE, ENDDATE)
                                    VALUES (@NAME, @STARTDATE, @ENDDATE)";
            command.Parameters.AddWithValue("@NAME", plan.Name);
            command.Parameters.AddWithValue("@STARTDATE", plan.StartDate);
            command.Parameters.AddWithValue("@ENDDATE", plan.EndDate);

            try
            {
                sql.Open();
                command.ExecuteNonQuery();
                return true;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex);
                return false;
            }
            finally
            {
                sql.Close();
            }
        }
        public bool UpdatePlan(Plan plan)
        {
            command.Connection = sql;
            command.CommandText = @"UPDATE PLAN SET NAME = @NAME, STARTDATE = @STARTDATE, 
                                    ENDDATE = @ENDDATE
                                    WHERE ID = @ID";
            command.Parameters.AddWithValue("@NAME", plan.Name);
            command.Parameters.AddWithValue("@STARTDATE", plan.StartDate);
            command.Parameters.AddWithValue("@ENDDATE", plan.EndDate);
            command.Parameters.AddWithValue("@ENDDATE", plan.Id);

            try
            {
                sql.Open();
                command.ExecuteNonQuery();
                return true;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex);
                return false;
            }
            finally
            {
                sql.Close();
            }
        }

        public bool DeletePlan(Plan plan)
        {
            command.Connection = sql;
            command.CommandText = @"DELETE FROM PLAN WHERE ID = @ID";
            command.Parameters.AddWithValue("@ENDDATE", plan.Id);

            try
            {
                sql.Open();
                command.ExecuteNonQuery();
                return true;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex);
                return false;
            }
            finally
            {
                sql.Close();
            }
        }
    }
}
