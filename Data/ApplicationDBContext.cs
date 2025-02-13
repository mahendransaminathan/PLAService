using Microsoft.EntityFrameworkCore;
using PLAService.Entities; // Ensure that the Person class is defined in this namespace or update to the correct namespace

namespace PLAService.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=Saminathan;Database=Person;TrustServerCertificate=True;");
            }
        }

        public DbSet<Person> People { get; set; }
    }
}
