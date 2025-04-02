namespace PicPaySimplificado.Domain.Interfaces
{
    public interface IAuthorizer
    {
        public Task<bool> IsAuthorizedAsync();
    }
}
