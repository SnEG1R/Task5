using Microsoft.EntityFrameworkCore;
using Task5.Domain;

namespace Task5.Persistence.Contexts;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Street> Streets { get; set; }
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Apartment> Apartments { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<FirstName> FirstNames { get; set; }
    public DbSet<LastName> LastNames { get; set; }
    public DbSet<NumberPhone> NumberPhones { get; set; }

    public ApplicationDbContext(DbContextOptions options) 
        : base(options)
    {
        Database.EnsureCreated();
    }
}