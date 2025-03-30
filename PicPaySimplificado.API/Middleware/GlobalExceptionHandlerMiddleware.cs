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

                //if (!isKnowException)
                    this.logger.LogError(ex.Message);

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }

        private bool IsKnownException(Exception ex) => 
            ex is AlreadyUsedException || 
            ex is AmountMustBeGreaterThanZeroException || 
            ex is InsufficientBalanceException ||
            ex is InvalidFormatException;
    }
}
