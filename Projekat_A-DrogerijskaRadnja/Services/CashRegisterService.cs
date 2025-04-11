using MySql.Data.MySqlClient;
using Projekat_A_DrogerijskaRadnja.Model;
using System.Collections.Generic;
using System.Configuration;
using cashRegister = Projekat_A_DrogerijskaRadnja.Model.CashRegister;

namespace Projekat_A_DrogerijskaRadnja.Services
{
    public class CashRegisterService
    {
        private readonly string connectionString;
        public CashRegisterService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }
        public List<cashRegister> getRegisters()
        {
            var registers = new List<cashRegister>();
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "SELECT IdKasa FROM kasa";

                var command = new MySqlCommand(query, connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        registers.Add(new CashRegister
                        {
                            CashRegisterId = reader.GetInt32("IdKasa")

                        }); 
                    }

                }
            }

            return registers;
        }
    }
}
