using CRUD_WEBAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeedbContext _context;

        public EmployeeController(EmployeedbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Employee> employeelist = _context.Employee.ToList();
            if(employeelist != null)
            {
                return Ok(employeelist);
            }
            else
            {
                return BadRequest();
            }
                
        }
        [HttpPost]
        public IActionResult Create([FromBody]Employee employee)
        {
            if (ModelState.IsValid)
            {
                var e = _context.Add(employee);
                _context.SaveChanges();
                return CreatedAtAction("Created", new {id = employee.Id},employee);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]int id)
        {
            var emp = _context.Employee.FirstOrDefault(i => i.Id == id);
            if (emp != null)
            {
                _context.Employee.Remove(emp);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Employee employee)
        {
            if (ModelState.IsValid)
            {
                var emp = _context.Employee.FirstOrDefault(i => i.Id == employee.Id );
                if(emp != null)
                {
                    emp.Name = employee.Name;
                    emp.Surname = employee.Surname;
                    emp.Position = employee.Position;
                    _context.Employee.Update(emp);
                    _context.SaveChanges();
                    return Ok(emp);
                }
                else
                {
                    return NotFound();
                }
                
            }else
            {
                return BadRequest(employee);
            }
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetItem(int id)
        {
            var emp = _context.Employee.FirstOrDefault(i => i.Id == id);
            if (emp != null)
            {
                return Ok(emp);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
