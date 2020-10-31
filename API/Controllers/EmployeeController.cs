using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost]
        [Route("FileUpload")]
        public async Task<IActionResult> FileUpload(IFormFile file)
        {
            await employeeService.ImportCSVFile(new StreamReader(file.OpenReadStream()));
            return Ok();
        }
    }
}
