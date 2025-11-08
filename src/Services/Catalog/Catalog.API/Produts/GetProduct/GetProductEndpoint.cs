
namespace Catalog.API.Produts.GetProduct
{
    public record GetProductsRequest(int? Pagenumber = 1,int? PageSize =10);

    public record GetProductsResponse(IEnumerable<Product> Products);


    public class GetProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async ([AsParameters] GetProductsRequest request,ISender sender) =>
            {
                var query = request.Adapt<GetProductQuery>();
                var result = await sender.Send(query);
                var response = result.Adapt<GetProductsResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProducts")
            .Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Gets all products")
            .WithDescription("Gets all products from the catalog.");
        }
    }
}
