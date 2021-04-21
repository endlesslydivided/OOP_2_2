using Lab11_.Classes;
using System.Data.Entity;

namespace Lab11_.Contexts
{
    public partial class ApplicationContext : System.Data.Entity.DbContext
    {
        public  DbSet<Products> Products { get; set; }
        public  DbSet<Reports> Reports { get; set; }
        public  DbSet<Users> Users { get; set; }
        public  DbSet<UsersData> UsersData { get; set; }
        public  DbSet<UsersParams> UsersParams { get; set; }
         
         public ApplicationContext() : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
