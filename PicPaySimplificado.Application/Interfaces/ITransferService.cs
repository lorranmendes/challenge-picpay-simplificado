namespace PicPaySimplificado.Application.Interfaces
{
    public interface ITransferService
    {
        public Task<Response<Guid>> AddAsync(Transfer transfer);
    }
}
