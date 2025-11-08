
namespace Catalog.API.Produts.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record UpdateProductResponse(bool IsSuccess);
    public class UpdateProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products", async (UpdateProductRequest request, ISender sender) =>
            {
                var command = new UpdateProductCommand(request.Id, request.Name, request.Category, request.Description, request.ImageFile, request.Price);
                var result = await sender.Send(command);
                var response = new UpdateProductResponse(result.IsSuccess);
                return Results.Ok(response);
            })
            .WithName("updateProduct")
            .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Updates an existing product")
            .WithDescription("Updates an existing product in the catalog with the provided details.");
        }
    }
}
