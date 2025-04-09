using MySql.Data.MySqlClient;
using Projekat_A_DrogerijskaRadnja.Model;
using System.Collections.Generic;
using System.Configuration;
using System;
using account = Projekat_A_DrogerijskaRadnja.Model.Account;
using System.Windows;

namespace Projekat_A_DrogerijskaRadnja.Services
{
    public class AccountService
    {
        private readonly string connectionString;
        public AccountService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }
        public List<account> getAccounts()
        {
            var accounts = new List<account>();
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "SELECT KorisnickoIme, Lozinka, IdNaloga FROM nalog";

                var command = new MySqlCommand(query, connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        accounts.Add(new Account
                        {
                            KorisnickoIme = reader.GetString("KorisnickoIme"),
                            Lozinka = reader.GetString("Lozinka"),
                            IdNaloga = reader.GetInt32("IdNaloga"),
                           
                        });
                    }
                 
                }
            }

            return accounts;
        }
        public void UpdateThemeForUser(string username, string password, string theme)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "UPDATE nalog SET Tema = @tema WHERE KorisnickoIme = @username AND Lozinka = @password";
                var command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@tema", theme);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public string GetUserTheme(string username, string password)
        {
            string theme = string.Empty;

            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Tema FROM nalog WHERE KorisnickoIme = @username AND Lozinka = @password";

                // Pripremi SQL komandu
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    try
                    {
                        if (reader.Read())
                        {
                            theme = reader.GetString("Tema");
                        }
                    }catch(Exception ex)
                    {
                        
                    }
                }
            }

            return theme;
        }

    }
}
