namespace PicPaySimplificado.API.Endpoints
{
    public static class UserEndpoints
    {
        public static void AddUserEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/users", async (UserNewDTO userNewDTO, IUserService userService, IMapper mapper) =>
            {
                var userNewDTOValidator = new UserNewDTOValidator();
                var validation = await userNewDTOValidator.ValidateAsync(userNewDTO);
                if (!validation.IsValid)
                    return Results.BadRequest(new CustomProblemDetails(HttpStatusCode.BadRequest, validation.Errors.Select(x => x.ErrorMessage)));

                var user = mapper.Map<User>(userNewDTO);
                var result = await userService.AddAsync(user);
                return Results.Ok(result);
            });
        }
    }
}
