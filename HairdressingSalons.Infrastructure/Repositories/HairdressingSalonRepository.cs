using HairdressingSalons.Domain.Entities;
using HairdressingSalons.Domain.Interfaces;
using HairdressingSalons.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HairdressingSalons.Infrastructure.Repositories;

internal class HairdressingSalonRepository : IHairdressingSalonRepository
{
    private readonly HairdressingSalonDbContext _dbContext;

    public HairdressingSalonRepository(HairdressingSalonDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task Commit()
        => _dbContext.SaveChangesAsync();

    public async Task Create(HairdressingSalon hairdressingSalon)
    {
        _dbContext.Add(hairdressingSalon);
        await _dbContext.SaveChangesAsync();
    }

	public async Task<IEnumerable<HairdressingSalon>> GetAll()
        => await _dbContext.HairdressingSalons.ToListAsync();

    public async Task<HairdressingSalon> GetByEncodedName(string encodedName)
        => await _dbContext.HairdressingSalons.FirstAsync(c => c.EncodedName == encodedName);

    public Task<HairdressingSalon?> GetByName(string name)
        => _dbContext.HairdressingSalons.FirstOrDefaultAsync(hs => hs.Name.ToLower() == name.ToLower());
}
