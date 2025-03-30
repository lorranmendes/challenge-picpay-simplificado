namespace PicPaySimplificado.Domain.Validators
{
    public class UserNewDTOValidator : AbstractValidator<UserNewDTO>
    {
        private const int MinimumLengthPassword = 8;
        public UserNewDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage(string.Format(DefaultMessages.RequiredField, "Nome"));

            RuleFor(x => x.Email)
                .NotEmpty()
                    .WithMessage(string.Format(DefaultMessages.RequiredField, "Email"))
                .SetValidator(new EmailValidator());

            RuleFor(x => x.Document)
                .NotEmpty()
                    .WithMessage(string.Format(DefaultMessages.RequiredField, "CPF/CNPJ"));

            RuleFor(x => x.Password)
                .NotEmpty()
                    .WithMessage(string.Format(DefaultMessages.RequiredField, "Senha"))
                .MinimumLength(MinimumLengthPassword)
                    .WithMessage(string.Format(DefaultMessages.MinimumLengthRequired, "Senha", MinimumLengthPassword));

            RuleFor(x => x.Type)
                .IsInEnum()
                    .WithMessage(string.Format(DefaultMessages.InvalidType, "Tipo de Usuário"));
        }
    }
}
