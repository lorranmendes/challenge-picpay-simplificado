namespace PicPaySimplificado.Domain.Validators
{
    public class EmailValidator : AbstractValidator<string>
    {
        private readonly Regex emailRegex = 
            new Regex("^(?![.-])(?!.*[.-]{2})[a-zA-Z0-9.-]+@[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9-]+)*\\.[a-zA-Z]{2,}$");
        public EmailValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                    .WithMessage(string.Format(DefaultMessages.RequiredField, "Email"))
                .Must(x => emailRegex.IsMatch(x))
                    .WithMessage(string.Format(DefaultMessages.InvalidFormat, "Email"));
        }
    }
}
