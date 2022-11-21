using Microsoft.EntityFrameworkCore;
using Task5.Domain;

namespace Task5.Application.Interfaces;

public interface IApplicationVillageDbContext
{
    DbSet<Country> Countries { get; set; }
    DbSet<Village> Villages { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}