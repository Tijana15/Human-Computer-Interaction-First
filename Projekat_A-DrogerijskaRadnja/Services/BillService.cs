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
                // Pokušaj da parsiraš string u DateTime
                DateTime parsedDate;
                if (DateTime.TryParseExact(selectedDate, "d.M.yyyy. HH:mm:ss",
                                           System.Globalization.CultureInfo.InvariantCulture,
                                           System.Globalization.DateTimeStyles.None, out parsedDate))
                {
                    // Izmeni upit da koristi DateTime
                    var query = "SELECT * FROM račun WHERE DATE(DatumVrijemeIzdavanja) = @Date";
                    var command = new MySqlCommand(query, connection);

                    // Dodaj parsedDate kao DateTime
                    command.Parameters.AddWithValue("@Date", parsedDate);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bills.Add(new Bill(
                                reader.GetInt32("IdRačun"),
                                reader.GetDateTime("DatumVrijemeIzdavanja"), // Vraća DateTime direktno
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
                    // Ako datum nije validan, obavesti korisnika
                    MessageBox.Show("Invalid date format.");
                }
            }
            return bills;
        }

    }
}
