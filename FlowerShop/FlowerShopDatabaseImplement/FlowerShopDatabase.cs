using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowerShopDatabaseImplement
{
    public class FlowerShopDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=FLowerShopDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().Property(m => m.ImplementerId).IsRequired(false);
            modelBuilder.Entity<MessageInfo>().Property(m => m.ClientId).IsRequired(false);
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Flower> Flowers { set; get; }
        public virtual DbSet<FlowerComponent> FlowerComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Implementer> Implementers { set; get; }
        public virtual DbSet<MessageInfo> MessagesInfo { set; get; }
    }
}
