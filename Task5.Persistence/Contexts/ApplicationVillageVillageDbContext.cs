using Microsoft.EntityFrameworkCore;
using Task5.Application.Interfaces;
using Task5.Domain;

namespace Task5.Persistence.Contexts;

public sealed class ApplicationVillageVillageDbContext : DbContext, IApplicationVillageDbContext
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<Village> Villages { get; set; }

    public ApplicationVillageVillageDbContext(DbContextOptions options) 
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
}