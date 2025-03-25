using MySql.Data.MySqlClient;
using Projekat_A_DrogerijskaRadnja.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using sellingItem = Projekat_A_DrogerijskaRadnja.Model.SellingItem;

namespace Projekat_A_DrogerijskaRadnja.Services
{
    class SellingItemService
    {
        private readonly string connectionString;

        public SellingItemService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }

        public SellingItemDetails GetSellingItemDetails(int productId)
        {
            var query = @"
            SELECT 
                sa.CijenaNabavna,
                n.DatumNabavke,
                d.Naziv AS DobavljacNaziv
            FROM 
                prodajni_artikl pa
            JOIN 
                stavka_nabavke sa ON pa.STAVKA_NABAVKE_NABAVLJANJE_IdNabavke = sa.NABAVLJANJE_IdNabavke
            JOIN 
                nabavljanje n ON sa.NABAVLJANJE_IdNabavke = n.IdNabavke
            JOIN 
                dobavljač d ON n.DOBAVLJAČ_IdDobavljač = d.IdDobavljač
            WHERE 
                pa.PROIZVOD_IdProizvod = @productId";

            using (var connection = new MySqlConnection(connectionString))
            {
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@productId", productId);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new SellingItemDetails
                        {
                            NabavnaCijena = reader.GetDecimal("CijenaNabavna"),
                            DatumNabavke = reader.GetDateTime("DatumNabavke"),
                            DobavljacNaziv = reader.GetString("DobavljacNaziv")
                        };
                    }
                }
            }

            return null;
        }
    


        public List<SellingItem> GetAllSellingItems()
        {
            var items = new List<sellingItem>();

            using (var connection = new MySqlConnection(connectionString))
            {
                const string query = @"
                SELECT 
                    pa.PROIZVOD_IdProizvod, 
                    pa.STAVKA_NABAVKE_NABAVLJANJE_IdNabavke, 
                    pa.Cijena,
                    p.Naziv, 
                    p.Opis, 
                    p.KoličinaNaStanju, 
                    p.Sastav, 
                    p.BREND_Naziv
                FROM prodajni_artikl pa
                JOIN proizvod p ON pa.PROIZVOD_IdProizvod = p.IdProizvod";
                var command = new MySqlCommand(query, connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new SellingItem
                        {
                            ProductId = reader.GetInt32("PROIZVOD_IdProizvod"),
                            PurchaseId = reader.GetInt32("STAVKA_NABAVKE_NABAVLJANJE_IdNabavke"),
                            Price = reader.GetDouble("Cijena"),
                            Product = new Product
                            {
                                ProductId = reader.GetInt32("PROIZVOD_IdProizvod"),
                                Name = reader.GetString("Naziv"),
                                Description = reader.GetString("Opis"),
                                QuantityAvailable = reader.GetInt32("KoličinaNaStanju"),
                                Integrities = reader.GetString("Sastav"),
                                Brand = reader.GetString("BREND_Naziv")
                            }

                        });
                    }
                }
            }

            return items;
        }

        public void DeleteSellingItem(int productId, int purchaseId)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                const string query = "DELETE FROM prodajni_artikl WHERE PROIZVOD_IdProizvod = @ProductId AND STAVKA_NABAVKE_NABAVLJANJE_IdNabavke = @PurchaseId";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", productId);
                command.Parameters.AddWithValue("@PurchaseId", purchaseId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AddSellingItem(SellingItem sellingItem)
        {
            using var connection = new MySqlConnection(connectionString);
            const string query = @"INSERT INTO prodajni_artikl (PROIZVOD_IdProizvod,STAVKA_NABAVKE_NABAVLJANJE_IdNabavke, Cijena) 
                                 VALUES (@ProductId,@PurchaseId,@Price)";

            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@ProductId", sellingItem.ProductId);
            command.Parameters.AddWithValue("@PurchaseId", sellingItem.PurchaseId);
            command.Parameters.AddWithValue("@Price", sellingItem.Price);
            connection.Open();
            command.ExecuteNonQuery();

        }
    }

}
