using Microsoft.EntityFrameworkCore;
using Udemy.EfCourse.Data.Entities;

namespace Udemy.EfCourse.Data.Contexts
{
    public class UdemyContext : DbContext
    {
        //products aynı zamanda tablo ismidir.
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SaleHistory> SaleHistories { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-N0E8FFP9;Database=Feyzi;TrustServerCertificate=True;Integrated Security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasNoKey();
            modelBuilder.Entity<Customer>().HasKey(c => c.Number);
            //eger iki tane istersek
            modelBuilder.Entity<Customer>().HasKey(c => new
            {
                c.Number,
                c.FirstName
            });

            modelBuilder.Entity<Product>().Property(p => p.Name).HasDefaultValueSql("'Urun ismi girilmemis'");
            modelBuilder.Entity<Product>().Property(p => p.CreatedTime).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique(true);
            //fluent api ornegi
            modelBuilder.Entity<Product>().ToTable(name: "KategoriTablom");
            modelBuilder.Entity<Category>().Property(p => p.Name).HasColumnName("category_name");
            modelBuilder.Entity<Category>().Property(p => p.Name).IsRequired(true);
            modelBuilder.Entity<Category>().Property(p => p.Name).HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnName("product_price");

            //OneToMany FluentApi{
            modelBuilder.Entity<Product>().HasMany(p => p.SalesHistory).
                WithOne(s => s.Product).HasForeignKey(x => x.ProductId);
            
            modelBuilder.Entity<SaleHistory>().HasOne(s=>s.Product).
                WithMany(x => x.SalesHistory).HasForeignKey(x => x.ProductId);
            //}

            //OneToOne {

            modelBuilder.Entity<Product>().HasOne(p => p.ProductDetail).
                WithOne(d => d.Product).HasForeignKey<ProductDetail>(x => x.ProductId);
            //}

            //ManyToMany

            modelBuilder.Entity<ProductCategory>().HasKey(x => new {x.ProductID, x.CategoryID});

            modelBuilder.Entity<Product>().HasMany(p => p.ProductCategories).WithOne(c => c.Product).
                HasForeignKey(x => x.ProductID);

            modelBuilder.Entity<Category>().HasMany(p => p.ProductCategories).WithOne(p => p.Category).
                HasForeignKey(x => x.CategoryID);   

            base.OnModelCreating(modelBuilder); 
        }
    }
}
