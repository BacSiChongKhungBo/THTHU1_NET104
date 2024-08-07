using Microsoft.EntityFrameworkCore;

namespace THTHU1_NET104.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        //Tao DBSet
        public DbSet<Hang> Hangs { get; set; }
        public DbSet<Oto> Otos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hang>().HasData(new Hang("H1", "Roll Royces"),
                                                new Hang("H2", "Balencicaca"));
        }
    }
}
