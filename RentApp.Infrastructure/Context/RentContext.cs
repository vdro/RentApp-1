using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RentApp.Infrastructure.Model;

namespace RentApp.Infrastructure.RentContext
{
  
}
    public class RentContext : DbContext
    {
        
        public DbSet<Flat> Flat { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<Address> Address { get; set; }
        
        public RentContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "DataSource=dbo.RentFlatApi.db");
        }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flat>()
                .HasMany(navigationExpression: x => x.Images)
                .WithOne(navigationExpression: y => y.Flat)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Flat>()
                .HasOne(navigationExpression: x => x.Owner)
                .WithMany(navigationExpression: y => y.Flats)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Flat>()
                .HasOne(navigationExpression: x => x.Tenant)
                .WithOne(navigationExpression: y => y.Flat)
                .HasForeignKey<Tenant>(z => z.Id);
        }
    }
    
