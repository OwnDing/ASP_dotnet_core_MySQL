using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace ASP_Sample.Models
{
    public class MvcBookContext : DbContext
    {
        //public MvcBookContext (DbContextOptions<MvcBookContext> options)
        //    : base(options)
        //{
        //}

        public DbSet<ASP_Sample.Models.Book> Book { get; set; }
        public string ConnectionString { get; set; }

        public MvcBookContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Book> GetAllFilms()
        {
            List<Book> list = new List<Book>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM books", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Book()
                        {
                            ID = reader.GetInt32("ID"),
                            Title = reader.GetString("title"),
                            Author = reader.GetString("author"),
                            ReleaseDate = reader.GetDateTime("releasedate"),
                            Price = reader.GetDecimal("price"),
                            Rating = reader.GetString("rating")
                        });
                    }
                }
            }

            return list;
        }

        public Book GetBookFromID(int id)
        {
            Book list = new Book();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM books where ID='"+id+"';", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        list.ID = reader.GetInt32("ID");
                        list.Title = reader.GetString("title");
                        list.Author = reader.GetString("author");
                        list.ReleaseDate = reader.GetDateTime("releasedate");
                        list.Price = reader.GetDecimal("price");
                        list.Rating = reader.GetString("rating");
                        
                    }
                }
            }
            //System.Diagnostics.Debug.WriteLine("id number:---"+id);
            return list;
        }
    }
}
