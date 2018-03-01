using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CoreWebAppSimple.Models
{
    public class SakilaContext
    {
        public string ConnectionString { get; set; }

        public SakilaContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Film> GetAllFilms()
        {
            List<Film> list = new List<Film>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM film", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Film()
                        {
                            FilmId = reader.GetInt32("film_id"),
                            Title = reader.GetString("title"),
                            Description = reader.GetString("description"),
                            ReleaseYear = reader.GetInt32("release_year"),
                            Length = reader.GetInt32("length"),
                            Rating = reader.GetString("rating")
                        });
                    }
                }
            }

            return list;

        }
    }
}
