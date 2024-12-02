using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;


public class DiscountContext : DbContext
{

    public DbSet<Coupon> Coupons { get; set; } = default!;

    public DiscountContext(DbContextOptions<DiscountContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon { Id = 1, ProductName = " Galaxy S24 Ultra", Description = "Some product description", Amount = 2000 },
            new Coupon { Id = 2, ProductName = " Galaxy S22 Ultra", Description = "Some product description", Amount = 1000 }
        );
    }

}

