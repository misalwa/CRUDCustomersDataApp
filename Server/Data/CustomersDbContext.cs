using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data;

public class CustomersDbContext : DbContext
{
    public CustomersDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
}
