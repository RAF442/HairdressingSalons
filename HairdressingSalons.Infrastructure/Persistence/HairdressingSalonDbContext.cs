using HairdressingSalons.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HairdressingSalons.Infrastructure.Persistence;

public class HairdressingSalonDbContext : IdentityDbContext
{
    public HairdressingSalonDbContext(DbContextOptions<HairdressingSalonDbContext> options) : base(options)
    {
    }

    public DbSet<HairdressingSalon> HairdressingSalons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<HairdressingSalon>()
            .OwnsOne(c => c.ContactDetails);
    }
}
