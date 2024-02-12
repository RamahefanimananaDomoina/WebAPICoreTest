using Microsoft.EntityFrameworkCore;
using ProjectTestDotNet.Model;

namespace ProjectTestDotNet.Repository
{
    public class Projectrepository : DbContext
    {
        public DbSet<Project> project { get; set; }
        private string ConnexionString = "Host=localhost;Username=postgres;Password=root;Database=public";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseNpgsql(ConnexionString);
            }
        }
    }
}
