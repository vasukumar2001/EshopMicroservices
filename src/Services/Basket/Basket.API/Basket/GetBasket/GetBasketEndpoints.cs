namespace Basket.API.Basket.GetBasket
{
     public record GetBasketRequest(string UserName);
    public record GetBasketRespose(ShoppingCart Cart);
    public class GetBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{userName}",async (string userName, ISender sender) =>
            {
                var result = await sender.Send(new GetBasketQurey(userName));

                var response = result.Adapt<GetBasketRespose>();

                return Results.Ok(response);

            })
            .WithName("Getbasket")
            .Produces<GetBasketRespose>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Gets basket")
            .WithDescription("Gets basket");
        }
    }
}
