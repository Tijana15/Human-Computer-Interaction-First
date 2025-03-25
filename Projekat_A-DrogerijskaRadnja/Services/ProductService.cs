using MySql.Data.MySqlClient;
using Projekat_A_DrogerijskaRadnja.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_A_DrogerijskaRadnja.Services
{
    public class ProductService
    {
        private readonly string connectionString;

        public ProductService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }
      
        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();

            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "SELECT Naziv, Opis,KoličinaNaStanju, Sastav, IdProizvod, KATEGORIJA_IdKategorija, BREND_Naziv FROM proizvod";

                var command = new MySqlCommand(query, connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = reader.GetInt32("IdProizvod"),
                            Name = reader.GetString("Naziv"),
                            Description = reader.GetString("Opis"),
                            QuantityAvailable = reader.GetInt32("KoličinaNaStanju"),
                            Integrities = reader.GetString("Sastav"),
                            CategoryId = reader.GetInt32("KATEGORIJA_IdKategorija"),
                            Brand = reader.GetString("BREND_Naziv")
                        });
                    }
                }
            }

            return products;
        }

    }
}
