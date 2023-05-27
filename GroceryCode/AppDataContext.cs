using Microsoft.EntityFrameworkCore;

namespace GroceryCode
{
    public class AppDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=App;Integrated Security=True;");


        }

        public DbSet<User> Users { get; set; }


    }
}
