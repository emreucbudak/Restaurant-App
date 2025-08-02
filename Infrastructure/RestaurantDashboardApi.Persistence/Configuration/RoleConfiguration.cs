using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantDashboardApi.Domain.Entities;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
            new Role()
            {
                Id = new Guid("11111111-1111-1111-1111-111111111111"),
                Name = "Waiter",
                NormalizedName = "WAITER",
                ConcurrencyStamp = "concurrency-waiter"
            },
            new Role()
            {
                Id = new Guid("22222222-2222-2222-2222-222222222222"),
                Name = "RestaurantCase",
                NormalizedName = "RESTAURANTCASE",
                ConcurrencyStamp = "concurrency-restaurantcase"
            },
            new Role()
            {
                Id = new Guid("33333333-3333-3333-3333-333333333333"),
                Name = "SystemAdmin",
                NormalizedName = "SYSTEMADMIN",
                ConcurrencyStamp = "concurrency-systemadmin"
            });
    }
}
