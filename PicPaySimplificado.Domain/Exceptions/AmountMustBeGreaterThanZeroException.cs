namespace PicPaySimplificado.Domain.Exceptions
{
    public class AmountMustBeGreaterThanZeroException : Exception
    {
        public AmountMustBeGreaterThanZeroException(string message) : base(message) { }
    }
}
