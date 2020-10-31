using DataLibrary.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataLibrary.Parsers
{
    public class EmployeeCSVParser
    {
        private const string CSV_DATE_FORMAT = "MM/dd/yyyy";

        private const int TITLE_INDEX = 0;
        private const int FIRSTNAME_INDEX = 1;
        private const int SURNAME_INDEX = 2;
        private const int GENDER_INDEX = 3;
        private const int DOB_INDEX = 4;
        private const int EMAIL_INDEX = 5;
        private const int JOB_TITLE_INDEX = 6;
        private const int SALARY_INDEX = 7;


        /// <summary>
        /// Reads a CSV string and parses it into an IEnumerable of employee objects
        /// </summary>
        /// <param name="reader">Reader object from which to read data</param>
        /// <returns></returns>
        public static IEnumerable<Employee> EmployeesFromCSV(TextReader reader)
        {
            List<Employee> employees = new List<Employee>();
            string line;
            while((line = reader.ReadLine()) != null)
            {
                string[] componenents = ReadCSVLine(line);
                employees.Add(new Employee()
                {
                    Title = componenents[TITLE_INDEX],
                    FirstName = componenents[FIRSTNAME_INDEX],
                    Surname = componenents[SURNAME_INDEX],
                    Gender = componenents[GENDER_INDEX],
                    DateOfBirth = DateTime.ParseExact(componenents[DOB_INDEX], CSV_DATE_FORMAT, null),
                    Email = componenents[EMAIL_INDEX],
                    JobTitle = componenents[JOB_TITLE_INDEX],
                    Salary = decimal.Parse(componenents[SALARY_INDEX]),
                });
            }
            return employees;
        }

        /// <summary>
        /// Splits a single line of a CSV file into its component parts
        /// </summary>
        /// <param name="line">Line of CSV</param>
        /// <returns></returns>
        private static string[] ReadCSVLine(string line)
        {
            List<string> stringList = new List<string>();
            StringBuilder currentString = new StringBuilder();
            bool inQuotes = false;
            // Read and parse each character in the CSV line
            for(int i = 0; i < line.Length; i++)
            {
                // If we are inside a outside a quote block, a comma is interpreted as a delimiter
                if(line[i] == ',')
                {
                    if(!inQuotes)
                    {
                        stringList.Add(currentString.ToString());
                        currentString.Clear();
                    } 
                    else
                    {
                        currentString.Append(',');
                    }
                } 
                else if (line[i] == '"')
                {
                    if(!inQuotes)
                    {
                        inQuotes = true;
                    } 
                    else 
                    {
                        if(i < line.Length - 1 && line[i + 1] == '"')
                        {
                            currentString.Append('"');
                            i++;
                        }
                        else
                        {
                            inQuotes = false;
                        }
                    }
                }
                else
                {
                    currentString.Append(line[i]);
                }
            }
            stringList.Add(currentString.ToString());
            return stringList.ToArray();
        }
        
    }
}
