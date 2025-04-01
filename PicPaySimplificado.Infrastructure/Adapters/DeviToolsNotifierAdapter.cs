namespace PicPaySimplificado.Infrastructure.Adapters
{
    public class DeviToolsNotifierAdapter : INotifier
    {
        public DeviToolsNotifierAdapter()
        {
            
        }

        public NotifiedDTO Notify() => new NotifiedDTO { Notified = true, Message = null };
    }
}
