using HairdressingSalons.Application.Dto;
using MediatR;

namespace HairdressingSalons.Application.Commands.CreateHairdressingSalon;

public class CreateHairdressingSalonCommand : HairdressingSalonDto, IRequest
{
}
