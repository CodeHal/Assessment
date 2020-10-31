using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Reads a CSV file from a stream and writes it to the database
        /// </summary>
        /// <param name="reader">Reader from which to read CSV</param>
        /// <returns></returns>
        Task ImportCSVFile(StreamReader reader);
    }
}
