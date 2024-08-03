using AutoMapper;
using HairdressingSalons.Application.Commands.CreateHairdressingSalon;
using HairdressingSalons.Application.Commands.EditHairdressingSalon;
using HairdressingSalons.Application.Queries.GetHairdressingSalonByEncodedName;
using HairdressingSalons.Application.Queries.NewFolder;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairdressingSalons.MVC.Controllers;

public class HairdressingSalonController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public HairdressingSalonController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var hairdressingSalons = await _mediator.Send(new GetAllHairdressingSalonsQuery());
        return View(hairdressingSalons);
    }

    [Route("HairdressingSalon/{encodedName}/Details")]
    public async Task<IActionResult> Details(string encodedName)
    {
        var dto = await _mediator.Send(new GetHairdressingSalonByEncodedNameQuery(encodedName));
        return View(dto);
    }

    [Route("HairdressingSalon/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await _mediator.Send(new GetHairdressingSalonByEncodedNameQuery(encodedName));

        EditHairdressingSalonCommand model = _mapper.Map<EditHairdressingSalonCommand>(dto);

        return View(model);
    }

    [HttpPost]
    [Route("HairdressingSalon/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName, EditHairdressingSalonCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Authorize] //Dodawanie formularza tylko przez zalogowanego użytkownika
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize] //Dodawanie formularza tylko przez zalogowanego użytkownika
    public async Task<IActionResult> Create(CreateHairdressingSalonCommand command)
    {
        if(!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }
}
