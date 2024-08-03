using FluentValidation;
using HairdressingSalons.Application.Dto;
using HairdressingSalons.Domain.Interfaces;

namespace HairdressingSalons.Application.Commands.CreateHairdressingSalon;

public class CreateHairdressingSalonCommandValidator : AbstractValidator<CreateHairdressingSalonCommand>
{
    public CreateHairdressingSalonCommandValidator(IHairdressingSalonRepository repository)
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MinimumLength(2).WithMessage("Name should have atleast 2 characters.")
            .MaximumLength(20).WithMessage("Name should have maximum of 20 characters.")
            .Custom((value, context) =>
            {
                var existingHairdressingSalon = repository.GetByName(value).Result;
                if (existingHairdressingSalon != null)
                {
                    context.AddFailure($"{value} is not unique name for hairdressing salon.");
                }
            });

        RuleFor(c => c.Description)
            .NotEmpty().WithMessage("Please enter description.");

        RuleFor(c => c.PhoneNumber)
            .MinimumLength(8)
            .MaximumLength(12);
    }
}
