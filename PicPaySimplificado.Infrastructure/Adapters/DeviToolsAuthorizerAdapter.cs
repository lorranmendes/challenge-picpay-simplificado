namespace PicPaySimplificado.Infrastructure.Adapters
{
    public class DeviToolsAuthorizerAdapter : IAuthorizer
    {
        public DeviToolsAuthorizerAdapter()
        {
            
        }

        public bool IsAuthorized() => true;
    }
}
