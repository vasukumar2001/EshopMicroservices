
namespace Basket.API.Basket.StoreBasket
{
    public record StroeBasketRequest(ShoppingCart Cart);

    public record StroeBasketRespose(string UserName);
    public class StroeBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async (StroeBasketRequest request, ISender sender) =>
            {
                var command = new StoreBasketCommand(request.Cart);
                var result = await sender.Send(command);
                var response = result.Adapt<StroeBasketRespose>();
                return Results.Created($"/basket/{response.UserName}",response);
            })
            .WithName("StroeBasket")
            .Produces<StroeBasketRespose>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Created Stores basket")
            .WithDescription("Created Stores basket");
        }
    }
}
