using DataLibrary.Entities;
using DataLibrary.Parsers;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace API.Services.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly InterviewContext interviewContext;

        public EmployeeService(InterviewContext interviewContext)
        {
            this.interviewContext = interviewContext;
        }

        public async Task ImportCSVFile(StreamReader reader)
        {
            IEnumerable<Employee> employees = EmployeeCSVParser.EmployeesFromCSV(reader);
            await interviewContext.AddRangeAsync(employees);
            await interviewContext.SaveChangesAsync();
        }

    }
}
