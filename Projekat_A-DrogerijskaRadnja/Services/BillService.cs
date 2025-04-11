using MySql.Data.MySqlClient;
using Projekat_A_DrogerijskaRadnja.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;

namespace Projekat_A_DrogerijskaRadnja.Services
{
    public class BillService
    {
        private readonly string connectionString;

        public BillService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }

        public List<Bill> GetAllBills()
        {
            var bills = new List<Bill>();
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "SELECT * FROM račun";
                var command = new MySqlCommand(query, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bills.Add(new Bill(
                            reader.GetInt32("IdRačun"),
                             reader.GetDateTime("DatumVrijemeIzdavanja"),
                            reader.GetString("NacinPlacanja"),
                            reader.GetDouble("Iznos"),
                            reader.GetInt32("KASA_IdKasa"),
                            reader.GetInt32("NALOG_IdNaloga")
                        ));
                    }
                }
            }
            return bills;
        }

        public List<Bill> GetBillsByDate(string selectedDate)
        {
            var bills = new List<Bill>();
            using (var connection = new MySqlConnection(connectionString))
            {
                DateTime parsedDate;
                if (DateTime.TryParseExact(selectedDate, "d.M.yyyy. HH:mm:ss",
                                           System.Globalization.CultureInfo.InvariantCulture,
                                           System.Globalization.DateTimeStyles.None, out parsedDate))
                {
                    var query = "SELECT * FROM račun WHERE DATE(DatumVrijemeIzdavanja) = @Date";
                    var command = new MySqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Date", parsedDate);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bills.Add(new Bill(
                                reader.GetInt32("IdRačun"),
                                reader.GetDateTime("DatumVrijemeIzdavanja"),
                                reader.GetString("NacinPlacanja"),
                                reader.GetDouble("Iznos"),
                                reader.GetInt32("KASA_IdKasa"),
                                reader.GetInt32("NALOG_IdNaloga")
                            ));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid date format.");
                }
            }
            return bills;
        }

        public int CreateBill(Bill bill)
        {
            int insertedId = -1;

            using (var connection = new MySqlConnection(connectionString))
            {
                string query = @"
            INSERT INTO račun (DatumVrijemeIzdavanja, NacinPlacanja, Iznos, KASA_IdKasa, NALOG_IdNaloga) 
            VALUES (@DatumVrijemeIzdavanja, @NacinPlacanja, @Iznos, @KasaId, @NalogId);
            SELECT LAST_INSERT_ID();";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DatumVrijemeIzdavanja", bill.DateTime);
                    command.Parameters.AddWithValue("@NacinPlacanja", bill.PayingMethod);
                    command.Parameters.AddWithValue("@Iznos", bill.Price);
                    command.Parameters.AddWithValue("@KasaId", bill.CashRegisterId);
                    command.Parameters.AddWithValue("@NalogId", bill.AccountId);

                    connection.Open();
                    insertedId = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return insertedId;
        }


    }
}
