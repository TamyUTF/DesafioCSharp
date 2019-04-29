using System;
using System.Collections.Generic;
using System.Data;
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
        internal static Dictionary<string, int> planDictionary = new Dictionary<string, int>();
        internal static List<Plan> planList = new List<Plan>();

        internal Dictionary<string, int> GetDictionary()
        {
            return planDictionary;
        }

        public List<Plan> GetList()
        {
            return planList;
        }
        public void ListAll()
        {
            command.Connection = sql;
            command.CommandText = "SELECT * FROM PLANS";
            if (sql.State == ConnectionState.Open)
            {
                sql.Close();
            }
            try
            {
                sql.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        planList.Add(new Plan((int)reader["ID"], reader["NAME"].ToString(), 
                                      Convert.ToDateTime(reader["STARTDATE"]), Convert.ToDateTime(reader["ENDDATE"])));
                    }
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex);
            }
            finally
            {
                command.Dispose();
                sql.Close();
            }
        }

        public bool InsertPlan(Plan plan)
        {
            command.Connection = sql;
            command.CommandText = @"INSERT INTO PLANS (NAME, STARTDATE, ENDDATE)
                                    VALUES (@NAME, @STARTDATE, @ENDDATE) SELECT SCOPE_IDENTITY()";
            command.Parameters.AddWithValue("@NAME", plan.Name);
            command.Parameters.AddWithValue("@STARTDATE", plan.StartDate);
            command.Parameters.AddWithValue("@ENDDATE", plan.EndDate);

            if (sql.State == ConnectionState.Open)
            {
                sql.Close();
            }
            try
            {
                sql.Open();
                var idOfInserted = Convert.ToInt32(command.ExecuteScalar());
                planList.Add(new Plan(idOfInserted, plan.Name, plan.StartDate, plan.EndDate));

                return true;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex);
                return false;
            }
            finally
            {
                command.Dispose();
                sql.Close();
            }
        }
        public bool UpdatePlan(Plan plan, int planId, int index)
        {
            command.Connection = sql;
            command.CommandText = @"UPDATE PLANS SET NAME = @NAME, STARTDATE = @STARTDATE, 
                                    ENDDATE = @ENDDATE
                                    WHERE ID = @ID";
            command.Parameters.AddWithValue("@NAME", plan.Name);
            command.Parameters.AddWithValue("@STARTDATE", plan.StartDate);
            command.Parameters.AddWithValue("@ENDDATE", plan.EndDate);
            command.Parameters.AddWithValue("@ID", planId);

            if (sql.State == ConnectionState.Open)
            {
                sql.Close();
            }
            try
            {
                sql.Open();
                command.ExecuteNonQuery();
                planList[index] = new Plan(planId, plan.Name, plan.StartDate, plan.StartDate);
                return true;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex);
                return false;
            }
            finally
            {
                command.Dispose();
                sql.Close();
            }
        }

        public bool DeletePlan(Plan plan)
        {
            command.Connection = sql;
            command.CommandText = "DELETE FROM PLANS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", plan.Id);

            if (sql.State == ConnectionState.Open)
            {
                sql.Close();
            }
            try
            {
                sql.Open();
                command.ExecuteNonQuery();
                planList.Remove(plan);
                return true;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex);
                return false;
            }
            finally
            {
                command.Dispose();
                sql.Close();
            }
        }
    }
}
