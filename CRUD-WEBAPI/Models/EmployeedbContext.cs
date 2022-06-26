using Microsoft.EntityFrameworkCore;

namespace CRUD_WEBAPI.Models
{
    public class EmployeedbContext:DbContext
    {
        public EmployeedbContext(DbContextOptions<EmployeedbContext> options):base(options)
        {
        }
        public DbSet<Employee> Employee { get; set; }
    }
}
