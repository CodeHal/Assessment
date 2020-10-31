using DataLibrary.Entities;
using DataLibrary.Parsers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataFileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check correct arguments passed in
            if(args.Length < 2)
            {
                Console.WriteLine("File to import and connection string must be specified in parameters, for example: DataFileReader.exe <Filename> <ConnectionString>");
                return;
            }

            string connectionString = args[1];
            string path = args[0];

            // Read employee objects from CSV
            IEnumerable<Employee> employees;
            try
            {
                using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read)))
                {
                    employees = EmployeeCSVParser.EmployeesFromCSV(reader);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Could not read data file.");
                return;
            }

            // Write employee objects to database
            try
            {
                using (InterviewContext ctx = new InterviewContext(new DbContextOptionsBuilder<InterviewContext>().UseSqlServer(connectionString).Options))
                {
                    ctx.AddRange(employees);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Could not import data into database.");
            }
        }

    }
}
