namespace IBASEmployeeService.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }


        [HttpGet("GetEmployees")]
        public IEnumerable<Employee> Get()
        {
            var employees = new List<Employee>()
            {
                new Employee()
                {
                    Id = "21",
                    Name = "Mette Bangsbo",
                    Age = 41,
                    Email = "meba@ibas.dk",
                    Department = new Department()
                    {
                        Id = 1,
                        Name = "Salg"
                    }
                },
                new Employee()
                {
                    Id = "22",
                    Name = "Hans Merkel",
                    Age = 54,
                    Email = "hame@ibas.dk",
                    Department = new Department()
                    {
                        Id = 2,
                        Name = "Support"
                    }
                },
                new Employee()
                {
                    Id = "23",
                    Name = "Karsten Mikkelsen",
                    Age = 32,
                    Email = "kami@ibas.dk",
                    Department = new Department()
                    {
                        Id = 2,
                        Name = "Support"
                    }
                },
                new Employee()
                {
                    Id = "24",
                    Name = "Jonathan Schmidt",
                    Age = 28,
                    Email = "Jona@ibas.dk",
                    Department = new Department()
                    {
                        Id = 3,
                        Name = "It"
                    }
                },
                new Employee()
                {
                    Id = "25",
                    Name = "Jane Sørensen",
                    Age = 47,
                    Email = "Jans@ibas.dk",
                    Department = new Department()
                    {
                        Id = 3,
                        Name = "It"
                    }
                },
                new Employee()
                {
                    Id = "26",
                    Name = "Peter Kjær",
                    Age = 36,
                    Email = "Pete@ibas.dk",
                    Department = new Department()
                    {
                        Id = 3,
                        Name = "It"
                    }
                },
                new Employee()
                {
                    Id = "27",
                    Name = "Sune Jorban",
                    Age = 25,
                    Email = "sunj@ibas.dk",
                    Department = new Department()
                    {
                        Id = 4,
                        Name = "Kantinen"
                    }
                },
                new Employee()
                {
                    Id = "28",
                    Name = "Lise Buur",
                    Age = 33,
                    Email = "lisb@ibas.dk",
                    Department = new Department()
                    {
                        Id = 4,
                        Name = "Kantinen"
                    }
                }
            };
            return employees;
        }

        [HttpGet("GetEmployeesByDepartment/{departmentId:int}")]
        public ActionResult<IEnumerable<Employee>> GetEmployeesByDepartment(int departmentId)
        {
            var employees = Get()
                .Where(employee => employee.Department.Id == departmentId)
                .ToList();

            if (!employees.Any())
            {
                return NotFound(); // Returner ikke 404
            }

            return Ok(employees);
        }
    }
}
