namespace PicPaySimplificado.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        /// <summary>
        /// CPF ou CNPJ
        /// </summary>
        public string Document { get; set; } = null!;
        public Email Email { get; set; }
        public string Password { get; set; } = null!;
        /// <summary>
        /// User types: Common or Merchant
        /// </summary>
        public UserTypeEnum Type { get; set; }

        public Wallet Wallet { get; set; }

        public User() { }
        public User(string name, string document, Email email, string password, UserTypeEnum type)
        {
            Name = name;
            Document = document;
            Email = email;
            Password = password;
            Type = type;
        }
    }
}
