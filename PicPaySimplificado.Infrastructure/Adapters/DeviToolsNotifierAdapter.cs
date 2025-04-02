namespace PicPaySimplificado.Infrastructure.Adapters
{
    public class DeviToolsNotifierAdapter : INotifier
    {
        private const string NotifierURL = "https://util.devi.tools/api/v1/notify";
        private readonly IHttpClientFactory httpClientFactory;
        public DeviToolsNotifierAdapter(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<NotifiedDTO> NotifyAsync()
        {
            using var client = httpClientFactory.CreateClient();

            var httpResponse = await client.PostAsync(NotifierURL, null);
            if (!httpResponse.IsSuccessStatusCode)
            {
                if (httpResponse.StatusCode == HttpStatusCode.GatewayTimeout)
                {
                    var response = await httpResponse.Content
                        .ReadFromJsonAsync<NotificationResponseDTO>() 
                            ?? throw new RequestFailedException(DefaultMessages.GenericError);

                    return new NotifiedDTO(Notified: false, Message: response.Message);
                }
                throw new RequestFailedException(DefaultMessages.GenericError);
            }
            return new NotifiedDTO(Notified: true);
        }
    }
}
