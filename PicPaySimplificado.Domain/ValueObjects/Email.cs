namespace PicPaySimplificado.Domain.ValueObjects
{
    public class Email
    {
        public string Address { get; private set; }
        public Email(string address)
        {
            var emailValidator = new EmailValidator();
            var validation = emailValidator.Validate(address);
            if (!validation.IsValid)
                throw new InvalidFormatException(validation.Errors.Select(x => x.ErrorMessage).FirstOrDefault());

            Address = address;
        }
    }
}
