using Microsoft.EntityFrameworkCore;
using Terrace240.DAL.Model;

namespace Terrace240.DAL
{
    public class MainContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<AdminPassword> AdminPasswords { get; set; }

        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=app.db");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
             
        }
    }
}
