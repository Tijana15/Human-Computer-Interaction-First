using MySql.Data.MySqlClient;
using Projekat_A_DrogerijskaRadnja.Model;
using System.Collections.Generic;
using System.Configuration;

namespace Projekat_A_DrogerijskaRadnja.Services
{
    public class BillItemBaseService
    {
        private readonly string connectionString;

        public BillItemBaseService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }
        public List<BaseBillItem> GetAllById(int billId)
        {
            List<BaseBillItem> items = new List<BaseBillItem>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
            SELECT
                p.IdProizvod AS ProductId,
                p.Naziv AS ProductName, -- Dodaj Naziv proizvoda
                sr.RAČUN_IdRačun AS BillId,
                sr.Količina AS Amount,
                sr.CijenaProdajna AS SellingPrice
            FROM
                stavka_racun sr
            JOIN
                prodajni_artikl pa ON sr.PRODAJNI_ARTIKL_PROIZVOD_IdProizvod = pa.PROIZVOD_IdProizvod
            JOIN
                proizvod p ON pa.PROIZVOD_IdProizvod = p.IdProizvod
            WHERE
                sr.RAČUN_IdRačun = @BillId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BillId", billId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BaseBillItem item = new BaseBillItem
                            {
                                ProductId = reader.GetInt32("ProductId"),
                                ProductName = reader.GetString("ProductName"), 
                                BillId = reader.GetInt32("BillId"),
                                Amount = reader.GetInt32("Amount"),
                                SellingPrice = reader.GetDouble("SellingPrice")
                            };
                            items.Add(item);
                        }
                    }
                }
            }

            return items;
        }
        public void AddBillItem(BaseBillItem item)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = @"
            INSERT INTO stavka_racun 
            (RAČUN_IdRačun, Količina, CijenaProdajna, PRODAJNI_ARTIKL_PROIZVOD_IdProizvod)
            VALUES (@BillId, @Amount, @SellingPrice, @ProductId);";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BillId", item.BillId);
                    command.Parameters.AddWithValue("@Amount", item.Amount);
                    command.Parameters.AddWithValue("@SellingPrice", item.SellingPrice);
                    command.Parameters.AddWithValue("@ProductId", item.ProductId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }



    }
}
