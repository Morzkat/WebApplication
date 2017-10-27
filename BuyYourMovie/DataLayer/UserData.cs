using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BuyYourMovie.DataLayer;
using BuyYourMovie.Models;
using Microsoft.Extensions.Configuration;

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
            throw new NotImplementedException();
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
                            reader["token"].ToString()
                            );        
                    }
                }
            }

            //Close the connection
            connection.Close();
            //Return all the movies
            return user;
        }

        public User GetByUserNameAndPw(string userEmail, string userPw)
        {
            User user = null;

            if (userEmail != " " && userPw != " ")
            {
                //Open the connection
                connection.Open();

                //Params for the search / Made a real_escape_string
                SqlParameter[] sqlParameter = new SqlParameter[2];

                sqlParameter[0] = new SqlParameter("userEmail", userEmail);
                sqlParameter[1] = new SqlParameter("userPw", userPw);

                //A Sql command o Query|Assign the query
                SqlCommand command = new SqlCommand("SELECT * FROM Users", connection);
                //Add the parameter to the query
                command.Parameters.Add(sqlParameter[0]);
                command.Parameters.Add(sqlParameter[1]);

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
                            reader["token"].ToString()
                            );
                    }
                }
            }

            //Close the connection
            connection.Close();
            //Return all the movies
            return user;
        }

        public bool Post(User newLog)
        {
            throw new NotImplementedException();
        }

        public bool Put(User updateLog, int id)
        {
            throw new NotImplementedException();
        }
    }
}
