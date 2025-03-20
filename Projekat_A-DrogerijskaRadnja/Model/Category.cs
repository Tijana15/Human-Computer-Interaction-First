using System;

namespace Projekat_A_DrogerijskaRadnja.Model
{
    public class Category
    { 
        public int CategoryId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int DepartmentId { get; set; }
        public override string ToString()
        {
            return $"ID: {CategoryId}, Name: {Name}, Description: {Description}, Department ID: {DepartmentId}";
        }

    }
}
