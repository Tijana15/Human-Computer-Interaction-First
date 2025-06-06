﻿using MySql.Data.MySqlClient;
using Projekat_A_DrogerijskaRadnja.Model;
using System.Collections.Generic;
using System.Configuration;
using System;
using account = Projekat_A_DrogerijskaRadnja.Model.Account;
using System.Windows;
using System.Data;

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
                var query = "SELECT KorisnickoIme, Lozinka, IdNaloga, jezik FROM nalog";

                var command = new MySqlCommand(query, connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string jezikValue = reader.IsDBNull("jezik") ? null : reader.GetString("jezik");
                        accounts.Add(new Account
                        {
                            KorisnickoIme = reader.GetString("KorisnickoIme"),
                            Lozinka = reader.GetString("Lozinka"),
                            IdNaloga = reader.GetInt32("IdNaloga"),
                            Jezik = jezikValue,

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
        public void UpdateLanguageForUser(string username, string password, string language)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "UPDATE nalog SET jezik = @jezik WHERE KorisnickoIme = @username AND Lozinka = @password";
                var command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@jezik", language);
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
        public string GetUserLanguage(string username, string password)
        {
            string language = string.Empty;

            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT jezik FROM nalog WHERE KorisnickoIme = @username AND Lozinka = @password";

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
                            language = reader.GetString("jezik");
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            return language;
        }
        public bool IsDirector(string username, string password)
        {
            int idNaloga = -1;

            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT IdNaloga FROM nalog WHERE KorisnickoIme = @username AND Lozinka = @password";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                connection.Open();
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    idNaloga = Convert.ToInt32(result);
                }
            }

            if (idNaloga == -1)
                return false;

            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM direktor WHERE NALOG_IdNaloga = @idNaloga";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@idNaloga", idNaloga);

                connection.Open();
                var count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }

    }
}
