using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp
{
    class UserDAO
    {
        public SqlConnection sql = new ConnectDb().DbConnect();
        public SqlCommand command = new SqlCommand();
        internal static Dictionary<int, User> userDictionary = new Dictionary<int, User>(); 
        internal static List<User> userList = new List<User>();

        public List<User> GetList()
        {
            return userList;
        }

        public List<User> Search(string search)
        {
            return userList.Where(u => u.FirstName.ToLower().Contains(search.ToLower()) || u.LastName.ToLower().Contains(search.ToLower())).ToList();
        }
        public void SelectAll()
        {
            command.Connection = sql;
            command.CommandText = "SELECT * FROM USERS";

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
                        if (!userDictionary.ContainsKey((int)reader["ID"]))
                        {
                            userDictionary.Add((int)reader["ID"], new User(reader["FIRSTNAME"].ToString(), reader["LASTNAME"].ToString(),
                                         Convert.ToDateTime(reader["BIRTH"]), (int)reader["PLANID"]));
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex);

            }
            finally
            {
                sql.Close();
            }

        }
        public void ListAll()
        {
            userList.Clear();
            foreach (var user in userDictionary)
            {
                userList.Add(new User(user.Key, user.Value.FirstName, user.Value.LastName, user.Value.Birth, user.Value.PlanId));
            }
        }
        public bool InsertUser(User user)
        {
            command.Connection = sql;
            command.CommandText = @"INSERT INTO USERS (FIRSTNAME,LASTNAME,BIRTH,PLANID)
                                    VALUES (@FIRSTNAME, @LASTNAME, @BIRTH, @PLANID)SELECT SCOPE_IDENTITY()";
            command.Parameters.AddWithValue("@FIRSTNAME", user.FirstName);
            command.Parameters.AddWithValue("@LASTNAME", user.LastName);
            command.Parameters.AddWithValue("@BIRTH", user.Birth);
            command.Parameters.AddWithValue("@PLANID", user.PlanId);

            if (sql.State == ConnectionState.Open)
            {
                sql.Close();   
            }
            try
            {
                sql.Open();
                var idOfInserted = Convert.ToInt32(command.ExecuteScalar());
                command.Parameters.Clear();
                userDictionary.Add(idOfInserted, new User(user.FirstName, user.LastName, user.Birth, user.PlanId));
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
        public bool UpdateUser(User user, int index)
        {
            Console.WriteLine(user.Id);
            command.Connection = sql;
            command.CommandText = @"UPDATE USERS SET 
                                    FIRSTNAME = @FIRSTNAME, LASTNAME = @LASTNAME,
                                    BIRTH = @BIRTH,PLANID = @PLANID
                                    WHERE ID = @ID";
            command.Parameters.AddWithValue("@FIRSTNAME", user.FirstName);
            command.Parameters.AddWithValue("@LASTNAME", user.LastName);
            command.Parameters.AddWithValue("@BIRTH", user.Birth);
            command.Parameters.AddWithValue("@PLANID", user.PlanId);
            command.Parameters.AddWithValue("@ID", user.Id);

            if (sql.State == ConnectionState.Open)
            {
                sql.Close();
            }
            try
            {
                sql.Open();
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                userDictionary[user.Id] = user;
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
        public bool DeletetUser(User user)
        {
            command.Connection = sql;
            command.CommandText = "DELETE FROM USERS WHERE ID = @ID";

            command.Parameters.AddWithValue("@ID", user.Id);

            try
            {
                if (sql.State == ConnectionState.Open)
                {
                    sql.Close();
                }
                sql.Open();
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                userDictionary.Remove(user.Id);
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

