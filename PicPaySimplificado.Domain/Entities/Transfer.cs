namespace PicPaySimplificado.Domain.Entities
{
    public class Transfer
    {
        public Guid Id { get; set; }
        public int IdPayer { get; set; }
        public int IdPayee { get; set; }
        public decimal Value { get; set; }

        public User Payer { get; set; }
        public User Payee { get; set; }

        public Transfer() { }
        public Transfer(int idPayer, int idPayee, decimal value)
        {
            IdPayer = idPayer;
            IdPayee = idPayee;
            Value = value;
        }
    }
}
