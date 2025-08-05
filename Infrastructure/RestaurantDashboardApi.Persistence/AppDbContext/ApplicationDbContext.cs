using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Persistence.AppDbContext
{
    public class ApplicationDbContext : IdentityDbContext<User,Role,Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }
        public DbSet<Desk> Desks { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory>  ProductCategories { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantCase> RestaurantsCase { get; set; }
        public DbSet<SystemAdmin> SystemAdmins { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<WaiterWorkStatus> waiterWorkStatuses { get; set; }
  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SystemAdmin>().HasKey(x => x.Id);
            modelBuilder.Entity<Waiter>().HasKey(x => x.Id);
            modelBuilder.Entity<RestaurantCase>().HasKey(x => x.Id);

; // ya da NoAction, ihtiyaca göre
            modelBuilder.Entity<Desk>()
    .HasOne(d => d.Restaurant)
    .WithMany(r => r.Desks)
    .HasForeignKey(d => d.RestaurantId)
    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Product>()
        .HasOne(p => p.Restaurant)
        .WithMany(r => r.Products)
        .HasForeignKey(p => p.RestaurantId)
        .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>()
        .HasMany(o => o.OrderItems)
        .WithOne(oi => oi.Order)
        .HasForeignKey(oi => oi.OrderId)
        .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Desk>()
    .HasOne(d => d.Order)
    .WithOne(o => o.Desk)
    .HasForeignKey<Order>(o => o.DeskId)
    .OnDelete(DeleteBehavior.Restrict);

        }
    }


    }

