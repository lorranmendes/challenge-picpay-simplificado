namespace PicPaySimplificado.Domain.DTOs
{
    public class TransferNewDTO
    {
        public int IdPayer { get; set; }
        public int IdPayee { get; set; }
        public decimal Value { get; set; }
    }
}
