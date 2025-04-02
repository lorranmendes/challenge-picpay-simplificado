namespace PicPaySimplificado.Domain.DTOs
{
    public class AuthorizationResponseDTO
    {
        public string Status { get; set; } = null!;
        public AuthorizationResponseDataDTO Data { get; set; } = null!;
    }

    public class  AuthorizationResponseDataDTO
    {
        public bool Authorization { get; set; }
    }
}
