namespace PicPaySimplificado.Infrastructure.Adapters
{
    public class DeviToolsAuthorizerAdapter : IAuthorizer
    {
        private const string AuthorizationURL = "https://util.devi.tools/api/v2/authorize";
        private readonly IHttpClientFactory httpClientFactory;
        public DeviToolsAuthorizerAdapter(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;            
        }

        public async Task<bool> IsAuthorizedAsync()
        {
            using var client = httpClientFactory.CreateClient();

            var httpResponse = await client.GetAsync(AuthorizationURL);

            var authorizationDTO = await httpResponse.Content
                .ReadFromJsonAsync<AuthorizationResponseDTO>() 
                    ?? throw new RequestFailedException(DefaultMessages.GenericError);

            return authorizationDTO.Data.Authorization;
        }
    }
}
