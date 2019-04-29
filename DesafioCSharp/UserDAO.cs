﻿using System;
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
        internal static List<User> userList = new List<User>();

        public List<User> GetList()
        {
            return userList;
        }
        public void ListAll()
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
                        userList.Add(new User((int)reader["ID"], reader["FIRSTNAME"].ToString(),reader["LASTNAME"].ToString(), 
                                     Convert.ToDateTime(reader["BIRTH"]), (int)reader["PLANID"]));
                    }
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex);

            }
            finally
            {
                sql.Dispose();
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
                var idOfInserted = Convert.ToInt32(command.ExecuteScalar());
                userList.Add(new User(idOfInserted,user.FirstName, user.LastName, user.Birth, user.PlanId));
            }
            try
            {
                sql.Open();
                command.ExecuteNonQuery();
                sql.Close();
                return true;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex);
                return false;
            }
            finally
            {
                sql.Dispose();
            }
        }
        public bool UpdateUser(User user, int userId, int index)
        {
            command.Connection = sql;
            command.CommandText = @"UPDATE USERS SET 
                                    FIRSTNAME = @FIRSTNAME, LASTNAME = @LASTNAME,
                                    BIRTH = @BIRTH,PLANID = @PLANID
                                    WHERE ID = @ID";
            command.Parameters.AddWithValue("@FIRSTNAME", user.FirstName);
            command.Parameters.AddWithValue("@LASTNAME", user.LastName);
            command.Parameters.AddWithValue("@BIRTH", user.Birth);
            command.Parameters.AddWithValue("@PLANID", user.PlanId);
            command.Parameters.AddWithValue("@ID", userId);

            try
            {
                sql.Open();
                command.ExecuteNonQuery();
                userList[index] = new User(userId, user.FirstName, user.LastName, user.Birth,user.PlanId);
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
        public bool DeletetUser(User user)
        {
            command.Connection = sql;
            command.CommandText = "DELETE FROM USERS WHERE ID = @ID";

            command.Parameters.AddWithValue("@ID", user.Id);

            try
            {
                sql.Open();
                command.ExecuteNonQuery();
                userList.Remove(user);
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
