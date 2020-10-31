using System;
using System.Collections.Generic;

namespace DataLibrary.Entities
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
    }
}
