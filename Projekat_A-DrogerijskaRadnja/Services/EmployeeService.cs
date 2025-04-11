using MySql.Data.MySqlClient;
using Projekat_A_DrogerijskaRadnja.Model;
using System.Collections.Generic;
using System.Configuration;

namespace Projekat_A_DrogerijskaRadnja.Services
{
   public class EmployeeService
    {
        private readonly string connectionString;

        public EmployeeService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }

        
        public List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "SELECT IdZaposlenog,Ime,Prezime, Telefon, Adresa, Smjena, Zaduženje, Plata, DatumZaposlenja FROM zaposleni";
                var command = new MySqlCommand(query, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            EmployeeId = reader.GetInt32("IdZaposlenog"),
                            Name = reader.GetString("Ime"),
                            LastName = reader.GetString("Prezime"),
                            Telephone = reader.GetString("Telefon"),
                            Address = reader.GetString("Adresa"),
                            Shift = reader.GetString("Smjena"),
                            Obligation = reader.GetString("Zaduženje"),
                            Salary = reader.GetDouble("Plata"),
                            HireDate = reader.GetDateTime("DatumZaposlenja")
                        });
                    }
                }
            }
            return employees;
        }

        public bool AddEmployee(Employee employee)
        {
                using var connection = new MySqlConnection(connectionString);
                const string query = @"INSERT INTO zaposleni (Ime, Prezime, Telefon, Adresa, Smjena, Zaduženje, Plata, DatumZaposlenja) 
                                   VALUES (@Ime, @Prezime, @Telefon, @Adresa, @Smjena, @Zaduženje, @Plata, @DatumZaposlenja)";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Ime", employee.Name);
                command.Parameters.AddWithValue("@Prezime", employee.LastName);
                command.Parameters.AddWithValue("@Telefon", employee.Telephone);
                command.Parameters.AddWithValue("@Adresa", employee.Address);
                command.Parameters.AddWithValue("@Smjena", employee.Shift);
                command.Parameters.AddWithValue("@Zaduženje", employee.Obligation);
                command.Parameters.AddWithValue("@Plata", employee.Salary);
                command.Parameters.AddWithValue("@DatumZaposlenja", employee.HireDate);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            
        }

        public void DeleteEmployee(int employeeId)
        {
            using var connection = new MySqlConnection(connectionString);
            const string query = "DELETE FROM zaposleni WHERE IdZaposlenog = @IdZaposlenog";
            var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdZaposlenog", employeeId);
            connection.Open();
            command.ExecuteNonQuery();
        }

        public void UpdateEmployee(Employee employee)
        {
            using var connection = new MySqlConnection(connectionString);
            const string query = @"UPDATE zaposleni 
                                   SET Ime = @Ime, Prezime = @Prezime, Telefon = @Telefon, Adresa = @Adresa, Smjena = @Smjena, 
                                       Zaduženje = @Zaduženje, Plata = @Plata, DatumZaposlenja = @DatumZaposlenja 
                                   WHERE IdZaposlenog = @IdZaposlenog";
            var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Ime", employee.Name);
            command.Parameters.AddWithValue("@Prezime", employee.LastName);
            command.Parameters.AddWithValue("@Telefon", employee.Telephone);
            command.Parameters.AddWithValue("@Adresa", employee.Address);
            command.Parameters.AddWithValue("@Smjena", employee.Shift);
            command.Parameters.AddWithValue("@Zaduženje", employee.Obligation);
            command.Parameters.AddWithValue("@Plata", employee.Salary);
            command.Parameters.AddWithValue("@DatumZaposlenja", employee.HireDate);
            command.Parameters.AddWithValue("@IdZaposlenog", employee.EmployeeId);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
