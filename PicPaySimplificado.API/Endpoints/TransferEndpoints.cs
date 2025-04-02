namespace PicPaySimplificado.API.Endpoints
{
    public static class TransferEndpoints
    {
        public static void AddTransferEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/transfers", async (TransferNewDTO transferNewDTO, ITransferService transferService, IMapper mapper) =>
            {
                var transferNewDTOValidator = new TransferNewDTOValidator();
                var validation = await transferNewDTOValidator.ValidateAsync(transferNewDTO);
                if (!validation.IsValid)
                    return Results.BadRequest(new CustomProblemDetails(HttpStatusCode.BadRequest, validation.Errors.Select(x => x.ErrorMessage)));

                var transfer = mapper.Map<Transfer>(transferNewDTO);
                var result = await transferService.AddAsync(transfer);
                return Results.Ok(result);
            });
        }
    }
}
