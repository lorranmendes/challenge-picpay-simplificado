namespace PicPaySimplificado.Domain.DTOs
{
    public class UserNewDTO
    {
        public string Name { get; set; } = null!;
        public string Document { get; set;} = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public UserTypeEnum Type { get; set; }
    }
}
