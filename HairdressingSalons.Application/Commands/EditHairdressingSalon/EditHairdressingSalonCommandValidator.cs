using FluentValidation;

namespace HairdressingSalons.Application.Commands.EditHairdressingSalon;

public class EditHairdressingSalonCommandValidator : AbstractValidator<EditHairdressingSalonCommand>
{
    public EditHairdressingSalonCommandValidator()
    {
        RuleFor(c => c.Description)
            .NotEmpty().WithMessage("Please enter description.");

        RuleFor(c => c.PhoneNumber)
            .MinimumLength(8)
            .MaximumLength(12);
    }
}
