using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BuyYourMovie.DataLayer;
using BuyYourMovie.Models;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace BuyYourMovie.DataLayer
{
    public class UserData : IDataLayer<User>
    {
        
        private SqlConnection connection;
        private String connectionString;
        public UserData(IConfiguration _configuration)
        {
            //The connection string with the direction the of DataBase, locate in the appsettings.json
            connectionString = _configuration.GetConnectionString("localDB");
            //Make the connection
            connection = new SqlConnection(connectionString);
        }
        SqlConnection IDataLayer<User>.connection
        {
            //Getter method for get the connection
            get => connection = new SqlConnection(connectionString);
        }

        public bool DeleteById(int id)
        {
            Boolean status = false;
            if (id != 0)
            {

                //Params for the insert / Made a real_escape_string
                SqlParameter sqlParameter = new SqlParameter("@id", id);

                //Assign the query
                var query = "delete from Users where id = @id";

                //Add the parameter to the query

                using (SqlConnection conne = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conne;
                        command.CommandType = CommandType.Text;
                        command.CommandText = query;
                        //Parameters added to the command
                        command.Parameters.Add(sqlParameter);

                        try
                        {
                            //Open the connection
                            conne.Open();
                            command.ExecuteNonQuery();
                            //Close the connection
                            conne.Close();
                            status = true;
                        }

                        catch (SqlException e)
                        {
                            Console.WriteLine("Error BD");
                            return false;
                        }
                    }
                }

            }
            return status;
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            User user = null;

            if (id != 0)
            {
                //Open the connection
                connection.Open();
                
                //Params for the search / Made a real_escape_string
                SqlParameter sqlParameter = new SqlParameter("@id", id);
                //A Sql command o Query|Assign the query
                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE id = @id",connection);
                //Add the parameter to the query
                command.Parameters.Add(sqlParameter);

                //Get all the values of the reader all the values came from the DB
                using (var reader = command.ExecuteReader())
                {
                    //While the reader has values
                    while (reader.Read())
                    {
                        //Create a new user
                        user = new User
                            (
                            Convert.ToInt32(reader["id"]),
                            reader["userEmail"].ToString(),
                            reader["userPw"].ToString(),
                            reader["token"].ToString(),
                            Convert.ToInt32(reader["level"])
                            );        
                    }
                }
            }

            //Close the connection
            connection.Close();
            //Return all the movies
            return user;
        }

        public User GetByToken(string token)
        {
            User user = null;

            if (token != " ")
            {
                //Open the connection
                connection.Open();

                //Params for the search / Made a real_escape_string
                SqlParameter sqlParameter = new SqlParameter("token", token);

                //A Sql command o Query|Assign the query
                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE token = @token", connection);
                //Add the parameter to the query
                command.Parameters.Add(sqlParameter);

                //Get all the values of the reader all the values came from the DB
                using (var reader = command.ExecuteReader())
                {
                    //While the reader has values
                    while (reader.Read())
                    {
                        //Create a new user
                        user = new User
                            (
                            Convert.ToInt32(reader["id"]),
                            reader["userEmail"].ToString(),
                            reader["userPw"].ToString(),
                            reader["token"].ToString(),
                            Convert.ToInt32(reader["level"])
                            );
                    }
                }
            }

            //Close the connection
            connection.Close();
            //Return all the movies
            return user;
        }

        public Boolean Post(User newLog)
        {
            bool status = false;
            if (newLog != null)
            {

                //Params for the insert / Made a real_escape_string
                SqlParameter[] sqlParameter = new SqlParameter[3];
                //Adding all params
                sqlParameter[0] = new SqlParameter("@userEmail", newLog.userEmail);
                sqlParameter[1] = new SqlParameter("@userPw", newLog.userPw);
                sqlParameter[2] = new SqlParameter("@token", newLog.userEmail);
                //Assign the query
                var query = "insert into Users (userEmail, userPw, token) VALUES " +
                    "(@userEmail, @userPw, @token);";
                //Add the parameter to the query

                using (SqlConnection conne = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conne;
                        command.CommandType = CommandType.Text;
                        command.CommandText = query;
                        //Parameters added to the command
                        command.Parameters.Add(sqlParameter[0]);
                        command.Parameters.Add(sqlParameter[1]);
                        command.Parameters.Add(sqlParameter[2]);
                        
                        try
                        {
                            //Open the connection
                            conne.Open();
                            command.ExecuteNonQuery();
                            //Close the connection
                            conne.Close();
                            //
                            status = true;
                        }

                        catch (SqlException e)
                        {
                            Console.WriteLine("Error BD");
                        }
                    }
                }

            }

            return status;
        }

        public bool Put(User updateLog, int id)
        {
            bool status = false;
            if (updateLog != null && id != 0 )
            {

                //Params for the insert / Made a real_escape_string
                SqlParameter[] sqlParameter = new SqlParameter[4];
                //Adding all params
                sqlParameter[0] = new SqlParameter("@userEmail", updateLog.userEmail);
                sqlParameter[1] = new SqlParameter("@userPw", updateLog.userPw);
                sqlParameter[2] = new SqlParameter("@level", updateLog.level);
                sqlParameter[3] = new SqlParameter("@id", id);
                //Assign the query
                var query = "UPDATE Users SET userEmail = @userEmail, userPw = @userPw, level = @level WHERE id = @id;";
                //Add the parameter to the query

                using (SqlConnection conne = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conne;
                        command.CommandType = CommandType.Text;
                        command.CommandText = query;
                        //Parameters added to the command
                        command.Parameters.Add(sqlParameter[0]);
                        command.Parameters.Add(sqlParameter[1]);
                        command.Parameters.Add(sqlParameter[2]);
                        command.Parameters.Add(sqlParameter[3]);

                        try
                        {
                            //Open the connection
                            conne.Open();
                            command.ExecuteNonQuery();
                            //Close the connection
                            conne.Close();
                            //
                            status = true;
                        }

                        catch (SqlException e)
                        {
                            Console.WriteLine("Error BD");
                        }
                    }
                }

            }

            return status;
        }
    }
}
