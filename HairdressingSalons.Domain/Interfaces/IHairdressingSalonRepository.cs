using HairdressingSalons.Domain.Entities;

namespace HairdressingSalons.Domain.Interfaces;

public interface IHairdressingSalonRepository
{
    Task Create(HairdressingSalon hairdressingSalon);

    Task<HairdressingSalon?> GetByName(string name);

    Task<IEnumerable<HairdressingSalon>> GetAll();

    Task<HairdressingSalon> GetByEncodedName(string encodedName);

    Task Commit();
}
