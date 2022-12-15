using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayerRepository
{
    public class AppDbContext:DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
           // var p = new Product() { ProductFeature = new ProductFeature(){ }}  yeni bir ürün eklerken ona ait feature ı da ekleyebiliriz.
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeature { get; set; }//yada varlı satır


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>().HasKey(x => x.Id);
            // bu yazım fluent api olarak adlandırılır haskeyden sonra metotlara devam edilebilir.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id = 1,
                Color = "Kırmızı",
                Height = 100,
                Width = 200,
                ProductId = 1

            }
            ,
          
            new ProductFeature()
            { 
                Id = 2,
                Color = "Mavi",
                Height = 300,
                Width = 400,
                ProductId = 2
            });






            base.OnModelCreating(modelBuilder);
        }
    }
}
