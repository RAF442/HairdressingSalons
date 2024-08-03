using AutoMapper;
using HairdressingSalons.Application.ApplicationUser;
using HairdressingSalons.Domain.Entities;
using HairdressingSalons.Domain.Interfaces;
using MediatR;

namespace HairdressingSalons.Application.Commands.CreateHairdressingSalon;

public class CreateHairdressingSalonCommandHandler : IRequestHandler<CreateHairdressingSalonCommand>
{
    private readonly IHairdressingSalonRepository _hairdressingSalonRepository;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public CreateHairdressingSalonCommandHandler(IHairdressingSalonRepository hairdressingSalonRepository, IMapper mapper, IUserContext userContext)
    {
        _hairdressingSalonRepository = hairdressingSalonRepository;
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task<Unit> Handle(CreateHairdressingSalonCommand request, CancellationToken cancellationToken)
    {
        var hairdressingSalon = _mapper.Map<HairdressingSalon>(request);
        hairdressingSalon.EncodeName();

        hairdressingSalon.CreatedById = _userContext.GetCurrentUser().Id; 

        await _hairdressingSalonRepository.Create(hairdressingSalon);

        return Unit.Value;
    }
}
