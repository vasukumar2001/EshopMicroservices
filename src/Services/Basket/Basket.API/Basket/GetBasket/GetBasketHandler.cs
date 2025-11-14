
namespace Basket.API.Basket.GetBasket
{
    public record GetBasketQurey(string UserName) : IQurey<GetBasketResult>;

    public record GetBasketResult(ShoppingCart Cart);

    public class GetBasketQureyHandler(IBasketRepository _repository) : IQureyHandler<GetBasketQurey, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQurey request, CancellationToken cancellationToken)
        {
            var basket = await _repository.GetBasket(request.UserName,cancellationToken).ConfigureAwait(false);

            return new GetBasketResult(basket);
        }
    }
}
