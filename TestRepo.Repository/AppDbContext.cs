using Microsoft.EntityFrameworkCore;
using TetPee.Repository.Entity;

namespace TetPee.Repository;

public class AppDbContext : DbContext
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Seller> Sellers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(builder =>
        {
            builder.Property(x => x.Email)
                .HasMaxLength(256)
                .IsRequired();
            builder.HasIndex(x => x.Email)
                .IsUnique();
            builder.Property(x => x.Password)
                .HasMaxLength(256)
                .IsRequired();
            builder.Property(x => x.Role)
                .HasMaxLength(256)
                .IsRequired();
            
            builder.HasOne(x => x.Seller)
                .WithOne(x => x.User)
                .HasForeignKey<Seller>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            var newUser = new User()
            {
                Id =  Guid.NewGuid(),
                Email = "admin@gmail.com",
                Password = "PiedTeam",
                Role = "Admin",
            };
            
            builder.HasData(newUser);
        });

        modelBuilder.Entity<Seller>(builder =>
        {
            builder.Property(x => x.TaxCode)
                .HasMaxLength(256)
                .IsRequired();
            builder.Property(x => x.CompanyAddress)
                .HasMaxLength(256)
                .IsRequired();
            builder.Property(x => x.CompanyName)
                .HasMaxLength(256)
                .IsRequired();
        });
        
        modelBuilder.Entity<Product>(builder =>
        {
            builder.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();
            builder.Property(x => x.Price)
                .HasMaxLength(256)
                .IsRequired();
            
            builder.HasOne(x => x.Seller)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.SellerId)
                .OnDelete(DeleteBehavior.Cascade);
        });    
        
        modelBuilder.Entity<Category>(builder =>
        {
            builder.Property(x => x.name)
                .HasMaxLength(256)
                .IsRequired();
            
            builder.HasOne(x => x.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Cascade);
        });    
    }
}