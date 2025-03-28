using System;

namespace Projekat_A_DrogerijskaRadnja.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string Shift { get; set; }
        public string Obligation { get; set; }
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }
        public Employee(int employeeId, string name, string lastName, string telephone, string address, string shift, string obligation, double salary, DateTime hireDate)
        {
            EmployeeId = employeeId;
            Name = name;
            LastName = lastName;
            Telephone = telephone;
            Address = address;
            Shift = shift;
            Obligation = obligation;
            Salary = salary;
            HireDate = hireDate;
        }
        public Employee() { }
    }
}
