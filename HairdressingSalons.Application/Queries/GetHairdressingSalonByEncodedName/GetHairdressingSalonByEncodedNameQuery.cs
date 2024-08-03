using HairdressingSalons.Application.Dto;
using MediatR;

namespace HairdressingSalons.Application.Queries.GetHairdressingSalonByEncodedName;

public class GetHairdressingSalonByEncodedNameQuery : IRequest<HairdressingSalonDto>
{
    public string EncodedName { get; set; }

    public GetHairdressingSalonByEncodedNameQuery(string encodedName)
    {
        EncodedName = encodedName;
    }
}
