using Microsoft.EntityFrameworkCore;

namespace RestApiCRUD.Models
{
    public class EmployeeContext: DbContext
    {   
        //shortcut: ctor + tab = constructor
        public EmployeeContext(DbContextOptions<EmployeeContext> options): base(options)
        {

        }
        //Table in the database
        public DbSet<Employee> Employees { get; set; }    

        //auto generated ids
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();    
        }
    }
}
