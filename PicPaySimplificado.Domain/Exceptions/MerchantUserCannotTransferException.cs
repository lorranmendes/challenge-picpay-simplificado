namespace PicPaySimplificado.Domain.Exceptions
{
    public class MerchantUserCannotTransferException : Exception
    {
        public MerchantUserCannotTransferException(string message) : base(message) { }
    }
}
