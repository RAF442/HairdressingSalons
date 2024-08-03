using HairdressingSalons.Domain.Interfaces;
using MediatR;

namespace HairdressingSalons.Application.Commands.EditHairdressingSalon;

internal class EditHairdressingSalonCommandHandler : IRequestHandler<EditHairdressingSalonCommand>
{
    private readonly IHairdressingSalonRepository _hairdressingSalonRepository;

    public EditHairdressingSalonCommandHandler(IHairdressingSalonRepository hairdressingSalonRepository)
    {
        _hairdressingSalonRepository = hairdressingSalonRepository;
    }

    public async Task<Unit> Handle(EditHairdressingSalonCommand request, CancellationToken cancellationToken)
    {
        var hairdressingSalon = await _hairdressingSalonRepository.GetByEncodedName(request.EncodedName!);

        hairdressingSalon.Description = request.Description;

        hairdressingSalon.ContactDetails.City = request.City;
        hairdressingSalon.ContactDetails.PhoneNumber = request.PhoneNumber;
        hairdressingSalon.ContactDetails.PostalCode = request.PostalCode;
        hairdressingSalon.ContactDetails.Street = request.Street;

        await _hairdressingSalonRepository.Commit();

        return Unit.Value;
    }
}
