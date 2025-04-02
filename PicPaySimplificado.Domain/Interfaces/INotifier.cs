namespace PicPaySimplificado.Domain.Interfaces
{
    public interface INotifier
    {
        public Task<NotifiedDTO> NotifyAsync();
    }
}
