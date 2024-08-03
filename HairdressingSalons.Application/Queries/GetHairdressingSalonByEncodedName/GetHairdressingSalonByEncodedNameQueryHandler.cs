using AutoMapper;
using HairdressingSalons.Application.Dto;
using HairdressingSalons.Domain.Interfaces;
using MediatR;

namespace HairdressingSalons.Application.Queries.GetHairdressingSalonByEncodedName;

public class GetHairdressingSalonByEncodedNameQueryHandler : IRequestHandler<GetHairdressingSalonByEncodedNameQuery, HairdressingSalonDto>
{
    private readonly IHairdressingSalonRepository _hairdressingSalonRepository;
    private readonly IMapper _mapper;

    public GetHairdressingSalonByEncodedNameQueryHandler(IHairdressingSalonRepository hairdressingSalonRepository, IMapper mapper)
    {
        _hairdressingSalonRepository = hairdressingSalonRepository;
        _mapper = mapper;
    }

    public async Task<HairdressingSalonDto> Handle(GetHairdressingSalonByEncodedNameQuery request, CancellationToken cancellationToken)
    {
        var hairdressingSalon = await _hairdressingSalonRepository.GetByEncodedName(request.EncodedName);

        var dto = _mapper.Map<HairdressingSalonDto>(hairdressingSalon);

        return dto;
    }
}
