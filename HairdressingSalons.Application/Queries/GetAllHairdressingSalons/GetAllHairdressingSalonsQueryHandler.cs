using AutoMapper;
using HairdressingSalons.Application.Dto;
using HairdressingSalons.Application.Queries.NewFolder;
using HairdressingSalons.Domain.Interfaces;
using MediatR;

namespace HairdressingSalons.Application.Queries.GetAllHairdressingSalons;

public class GetAllHairdressingSalonsQueryHandler : IRequestHandler<GetAllHairdressingSalonsQuery, IEnumerable<HairdressingSalonDto>>
{
    private readonly IHairdressingSalonRepository _hairdressingSalonRepository;
    private readonly IMapper _mapper;

    public GetAllHairdressingSalonsQueryHandler(IHairdressingSalonRepository hairdressingSalonRepository, IMapper mapper)
    {
        _hairdressingSalonRepository = hairdressingSalonRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<HairdressingSalonDto>> Handle(GetAllHairdressingSalonsQuery request, CancellationToken cancellationToken)
    {
        var hairdressingSalons = await _hairdressingSalonRepository.GetAll();
        var dtos = _mapper.Map<IEnumerable<HairdressingSalonDto>>(hairdressingSalons);

        return dtos;
    }
}
