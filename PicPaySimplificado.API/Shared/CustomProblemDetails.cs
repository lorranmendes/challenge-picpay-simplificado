namespace PicPaySimplificado.API.Shared
{
    public class CustomProblemDetails : ProblemDetails
    {
        public List<string> Errors { get; private set; } = new List<string>();
        public CustomProblemDetails(HttpStatusCode statusCode, IEnumerable<string>? errors = null)
        {            
            Title = statusCode switch
            {
                HttpStatusCode.BadRequest => "One or more validation errors occurred.",
                HttpStatusCode.InternalServerError => "Internal server error.",
                _ => "An error has occurred."
            };

            Status = (int)statusCode;

            if (errors is not null)
            {
                var errorList = errors.ToList();
                Detail = this.DefiningErrorsInDetail(errorList);
                Errors = errorList;
            }
            else Detail = string.Empty;
        }

        public CustomProblemDetails(HttpStatusCode statusCode, HttpRequest request, IEnumerable<string>? errors = null) : this(statusCode, errors)
            => Instance = request.Path;

        private string? DefiningErrorsInDetail(List<string> errors) => errors.Count switch
        {
            1 => errors.First(),
            > 1 => "Multiple problems have occurred.",
            _ => string.Empty
        };
    }
}
