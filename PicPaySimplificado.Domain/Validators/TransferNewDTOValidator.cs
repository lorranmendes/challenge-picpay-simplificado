namespace PicPaySimplificado.Domain.Validators
{
    public class TransferNewDTOValidator : AbstractValidator<TransferNewDTO>
    {
        public TransferNewDTOValidator()
        {
            RuleFor(x => x.IdPayer)
                .NotEmpty()
                    .WithMessage(string.Format(DefaultMessages.RequiredField, "Usuário pagador"));

            RuleFor(x => x.IdPayee)
                .NotEmpty()
                    .WithMessage(string.Format(DefaultMessages.RequiredField, "Usuário recebedor"));

            RuleFor(x => x.Value)
                .GreaterThan(0)
                    .WithMessage(string.Format(DefaultMessages.ValueMustBeGreaterThanZero, "Valor"));
        }
    }
}
