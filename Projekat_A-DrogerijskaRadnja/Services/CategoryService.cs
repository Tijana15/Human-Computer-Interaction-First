using MySql.Data.MySqlClient;
using Projekat_A_DrogerijskaRadnja.Model;
using System.Collections.Generic;
using System.Configuration;
using category = Projekat_A_DrogerijskaRadnja.Model.Category;

namespace Projekat_A_DrogerijskaRadnja.Services
{
    class CategoryService
    {
        private readonly string connectionString;
        public CategoryService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }
        public List<category> GetCategories()
        {
            var categories = new List<category>();
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "SELECT Naziv, Opis, IdKategorija FROM kategorija";

                var command = new MySqlCommand(query, connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categories.Add(new Category
                        {
                            Name = reader.GetString("Naziv"),
                            CategoryId = reader.GetInt32("IdKategorija"),
                            Description = reader.GetString("Opis"),
                        });
                    }

                }
            }

            return categories;
        }
        public void AddCategory(Category category)
        {
            using var connection = new MySqlConnection(connectionString);
            const string query = @"INSERT INTO kategorija (Naziv,Opis,ODJEL_IdOdjela) 
                                 VALUES (@Name,@Description,@DepartmentId)";

            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", category.Name);
            command.Parameters.AddWithValue("@Description", category.Description);
            command.Parameters.AddWithValue("@DepartmentId", category.DepartmentId);
            connection.Open();
            command.ExecuteNonQuery();

        }
        public void DeleteCategory(int categoryId)
        {
            using var connection = new MySqlConnection(connectionString);
            const string query = "DELETE FROM kategorija WHERE IdKategorija = @CategoryId";
            var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@CategoryId", categoryId);
            connection.Open();
            command.ExecuteNonQuery();
        }
        public void UpdateCategory(Category category)
        {
            using var connection = new MySqlConnection(connectionString);
            const string query = @"UPDATE kategorija 
                                   SET Naziv = @Name, Opis = @Description, ODJEL_IdOdjela = @DepartmentId 
                                   WHERE IdKategorija = @CategoryId";
            var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", category.Name);
            command.Parameters.AddWithValue("@Description", category.Description);
            command.Parameters.AddWithValue("@DepartmentId", category.DepartmentId);
            command.Parameters.AddWithValue("@CategoryId", category.CategoryId);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}

