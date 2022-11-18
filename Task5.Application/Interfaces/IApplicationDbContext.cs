using Microsoft.EntityFrameworkCore;
using Task5.Domain;

namespace Task5.Application.Interfaces;

public interface IApplicationDbContext
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

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}