using MySql.Data.MySqlClient;
using Projekat_A_DrogerijskaRadnja.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using department = Projekat_A_DrogerijskaRadnja.Model.Department;

namespace Projekat_A_DrogerijskaRadnja.Services
{
    public class DepartmentService
    {
        private readonly string connectionString;
        public DepartmentService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }
        public List<department> getDepartments()
        {
            var departments = new List<department>();
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "SELECT Naziv,IdOdjela  FROM odjel";

                var command = new MySqlCommand(query, connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        departments.Add(new Department
                        {
                            Name = reader.GetString("Naziv"),
                            Id_Department = reader.GetInt32("IdOdjela"),
                        });
                    }

                }
            }

            return departments;
        }

        public bool addDepartment(Department department)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                const string query = @"INSERT INTO odjel (naziv ) 
                                 VALUES (@Name)";

                using (var command = new MySqlCommand(query, connection))
                {
                    // Dodaj parametre
                    command.Parameters.AddWithValue("@Name", department.Name);

                    connection.Open();
                    int affectedRows = command.ExecuteNonQuery();

                    return affectedRows > 0;
                }
            }
        }

    }
}
