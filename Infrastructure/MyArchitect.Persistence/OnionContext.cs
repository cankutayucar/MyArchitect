using Microsoft.EntityFrameworkCore;
using MyArchitect.Domain.Entities;

namespace MyArchitect.Persistence
{
    public class OnionContext : DbContext
    {
        public OnionContext(DbContextOptions<OnionContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Category Mappings
            modelBuilder.Entity<Category>().HasKey(c => c.Id);

            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired(false)
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<Category>()
                .Property(c => c.Description)
                .IsRequired(false)
                .HasColumnType("varchar(150)");
            #endregion

            #region Product Mappings
            modelBuilder.Entity<Product>()
                    .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired(false)
                .HasColumnType("varchar(70)");

            modelBuilder.Entity<Product>()
                .Property(p => p.UnitInStock)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
            #endregion


        }
    }
}
