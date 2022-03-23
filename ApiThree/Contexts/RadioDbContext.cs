using ApiThree.Maps;
using ApiThree.Models;
using Microsoft.EntityFrameworkCore;
namespace ApiThree.Contexts
{


    public class RadioDbContext : DbContext
    {
        public RadioDbContext(DbContextOptions<RadioDbContext> options)
       : base(options)
        {

        }
        public DbSet<Radio> Todos { get; set; }
       // public DbSet<Radio> Radio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            new LinkMap(modelBuilder.Entity<Radio>());

        }
    }
}