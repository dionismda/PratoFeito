namespace _Architecture.Application.ValueObjects.Validators;

public class PersonNameValidator : AbstractValidator<PersonName>
{
    public PersonNameValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3)
            .MaximumLength(50);

        RuleFor(x => x.LastName)
            .NotNull()
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(200);
    }
}