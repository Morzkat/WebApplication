using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using BuyYourMovie.Models;
using System.Data;

namespace BuyYourMovie.DataLayer
{
    //Class for comunicate with the DataBase
    public class MovieData : IDataLayer<Movie>
    {
        //The connection with the db
        private SqlConnection connection;
        private String connectionString; 
        public MovieData(IConfiguration configuration)
        {
            //The connection string with the direction the of DataBase, locate in the appsettings.json
            connectionString = configuration.GetConnectionString("localDB");
            //Make the connection
            connection = new SqlConnection(connectionString);
        }

        SqlConnection IDataLayer<Movie>.connection
        {
            //Getter method for get the connection
            get => connection = new SqlConnection(connectionString);
        }

        //Delete by id
        public bool DeleteById(int id)
        {
            return true;
        }

        //Get all the movies in the DataBase
        public IEnumerable<Movie> GetAll()
        {
            connection = new SqlConnection(connectionString);
            //Open the connection
            connection.Open();

            //A list of movies
            List<Movie> movies = new List<Movie>();
            //A Sql command o Query|
            SqlCommand command = new SqlCommand("SELECT * FROM Movie", connection);
            
            //Get all the values of the reader all the values came from the DB
            using (var reader = command.ExecuteReader())
            {
                //While the reader has values
                while (reader.Read())
                {
                    //Create a new movie
                    Movie movie = new Movie
                        (
                        Convert.ToInt32(reader["id"]), 
                        reader["movieName"].ToString(), 
                        reader["movieSipnosis"].ToString(), 
                        reader["movieGender"].ToString(), 
                        reader["moviePublished"].ToString(), 
                        reader["movieImage"].ToString(), 
                        Convert.ToInt32(reader["starts"])
                        );
                    //Add the movie to the list of movies
                    movies.Add(movie);
                }
            }

            //Close the connection
            connection.Close();
            //Return all the movies
            return movies;
        }

        public Movie GetById(int id)
        {
            Movie movie = null;

            if (id != 0)
            {
                //Open the connection
                connection.Open();
                
                //Params for the search / Made a real_escape_string
                SqlParameter sqlParameter = new SqlParameter("@id", id);
                //A Sql command o Query|Assign the query
                SqlCommand command = new SqlCommand("SELECT * FROM Movie WHERE id = @id",connection);
                //Add the parameter to the query
                command.Parameters.Add(sqlParameter);

                //Get all the values of the reader all the values came from the DB
                using (var reader = command.ExecuteReader())
                {
                    //While the reader has values
                    while (reader.Read())
                    {
                        //Create a new movie
                        movie = new Movie
                            (
                            Convert.ToInt32(reader["id"]),
                            reader["movieName"].ToString(),
                            reader["movieSipnosis"].ToString(),
                            reader["movieGender"].ToString(),
                            reader["moviePublished"].ToString(),
                            reader["movieImage"].ToString(),
                            Convert.ToInt32(reader["starts"])
                            );        
                    }
                }
            }

            //Close the connection
            connection.Close();
            //Return all the movies
            return movie;
        }

        public IEnumerable<Movie> GetByMovieName(string movieName)
        {
            List<Movie> movies = new List<Movie>();

            if (movieName != " ")
            {
                //Open the connection
                connection.Open();

                //Params for the search / Made a real_escape_string
                SqlParameter sqlParameter = new SqlParameter("@movieName", movieName);
                //A Sql command o Query|Assign the query
                SqlCommand command = new SqlCommand("SELECT * FROM Movie WHERE movieName = @movieName", connection); ;
                //
                
                //Add the parameter to the query
                command.Parameters.Add(sqlParameter);

                //Get all the values of the reader all the values came from the DB
                using (var reader = command.ExecuteReader())
                {
                    //While the reader has values
                    while (reader.Read())
                    {
                        //Create a new movie
                        Movie movie = new Movie
                            (
                            Convert.ToInt32(reader["id"]),
                            reader["movieName"].ToString(),
                            reader["movieSipnosis"].ToString(),
                            reader["movieGender"].ToString(),
                            reader["moviePublished"].ToString(),
                            reader["movieImage"].ToString(),
                            Convert.ToInt32(reader["starts"])
                            );

                        movies.Add(movie);
                    }
                }
            }

            //Close the connection
            connection.Close();
            //Return all the movies
            return movies;
        }

        public Boolean Post(Movie newLog)
        {
            Boolean status = false;
            if (newLog != null )
            {
                
                //Params for the insert / Made a real_escape_string
                SqlParameter[] sqlParameter = new SqlParameter[6];
                //Adding all params
                sqlParameter[0] = new SqlParameter("@movieName", newLog.movieName);
                sqlParameter[1] = new SqlParameter("@movieSipnosis", newLog.movieSipnosis);
                sqlParameter[2] = new SqlParameter("@movieGender", newLog.movieGender);
                sqlParameter[3] = new SqlParameter("@moviePublished", newLog.moviePublished);
                sqlParameter[4] = new SqlParameter("@movieImage", newLog.image);
                sqlParameter[5] = new SqlParameter("@starts", newLog.starts);

                //Assign the query
               var query = "insert into Movie (movieName, movieSipnosis, movieGender, " +
                    "moviePublished, movieImage, starts) VALUES (@movieName, @movieSipnosis, @movieGender, " +
                    "@moviePublished, @movieImage, @starts);";
                //Add the parameter to the query

                using (SqlConnection conne = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conne;
                        command.CommandType = CommandType.Text;
                        command.CommandText = query;
                        //
                        command.Parameters.Add(sqlParameter[0]);
                        command.Parameters.Add(sqlParameter[1]);
                        command.Parameters.Add(sqlParameter[2]);
                        command.Parameters.Add(sqlParameter[3]);
                        command.Parameters.Add(sqlParameter[4]);
                        command.Parameters.Add(sqlParameter[5]);

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

        public bool Put(Movie updateLog)
        {
            throw new NotImplementedException();
        }
    }
}
