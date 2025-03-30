namespace PicPaySimplificado.Application.Interfaces
{
    public interface IUserService
    {
        public Task<Response<int>> AddAsync(User user);
    }
}
