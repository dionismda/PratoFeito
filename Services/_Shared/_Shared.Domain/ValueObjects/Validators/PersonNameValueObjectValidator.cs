namespace _Shared.Domain.ValueObjects.Validators;

public class PersonNameValueObjectValidator : AbstractValidator<PersonNameValueObject>
{
    public PersonNameValueObjectValidator()
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
