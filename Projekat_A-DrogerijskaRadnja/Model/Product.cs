using System;

namespace Projekat_A_DrogerijskaRadnja.Model
{
   public class Product
    {
        public int ProductId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int QuantityAvailable { get; set; }
        public String Integrities { get; set; }
        public int CategoryId { get; set; }
        public String Brand { get; set; }

        public Product() { }

        public Product(int productId, string name, string description, int quantityAvailable, string integrities, int categoryId, string brand)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            QuantityAvailable = quantityAvailable;
            Integrities = integrities;
            CategoryId = categoryId;
            Brand = brand;
        }

        public Product(int productId, string name, string description, int quantityAvailable, string integrities, string brand)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            QuantityAvailable = quantityAvailable;
            Integrities = integrities;
            Brand = brand;
        }

    }
}
