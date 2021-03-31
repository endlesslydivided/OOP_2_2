using Lab11.Classes;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Lab11.Contexts
{
        public class ApplicationContext : DbContext
        {
            public DbSet<Products> Products { get; set; }

            public ApplicationContext()
            {
                Database.EnsureCreated();
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
            }
        }
}
