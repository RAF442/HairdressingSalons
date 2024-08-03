using HairdressingSalons.Application.Dto;
using MediatR;

namespace HairdressingSalons.Application.Queries.NewFolder;

public class GetAllHairdressingSalonsQuery : IRequest<IEnumerable<HairdressingSalonDto>>
{
}
