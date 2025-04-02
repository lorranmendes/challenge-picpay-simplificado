namespace PicPaySimplificado.API.Middleware
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlerMiddleware> logger;
        public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            this.logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var isKnowException = IsKnownException(ex);

                var problemDetails = new ProblemDetails
                {
                    Type = $"https://httpstatuses.io/{(int)context.Response.StatusCode}",
                    Title = "Internal Server Error",
                    Status = (int)StatusCodes.Status500InternalServerError,
                    Detail = isKnowException ? ex.Message : DefaultMessages.GenericError,
                    Instance = context.Request.Path
                };

                this.logger.LogError(ex.Message);

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }

        /// <summary>
        /// Uma alternativa, em caso de crescimento do projeto, 
        /// seria criar Exceptions específicas por camada de projeto e não por funcionalidade.
        /// </summary>
        private bool IsKnownException(Exception ex) =>
            ex is AlreadyUsedException ||
            ex is AmountMustBeGreaterThanZeroException ||
            ex is InsufficientBalanceException ||
            ex is InvalidFormatException ||
            ex is MerchantUserCannotTransferException ||
            ex is NotAuthorizedException ||
            ex is NotFoundException ||
            ex is NotifyServiceOfflineException ||
            ex is RequestFailedException;
    }
}
