using ApiThree.Maps;
using ApiThree.Models;
using Microsoft.EntityFrameworkCore;
namespace ApiThree.Contexts
{


    public class InputDbContext : DbContext
    {
        public InputDbContext(DbContextOptions<InputDbContext> options)
       : base(options)
        {

        }
        public DbSet<InputRF> Todos { get; set; }
      //  public DbSet<InputRF> InputRF  { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            new InputPowerMap(modelBuilder.Entity<InputRF>());

        }
    }
}