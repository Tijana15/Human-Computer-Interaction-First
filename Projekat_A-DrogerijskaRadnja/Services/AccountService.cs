using MySql.Data.MySqlClient;
using Projekat_A_DrogerijskaRadnja.Model;
using System.Collections.Generic;
using System.Configuration;
using account = Projekat_A_DrogerijskaRadnja.Model.Account;

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
    }
}
