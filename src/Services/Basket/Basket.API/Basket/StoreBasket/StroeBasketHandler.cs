
namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

    public record StoreBasketResult(string UserName);

    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not null");
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.Cart.Items).NotNull();
        }
    }

    public class StroeBasketCommandHandler(IBasketRepository _repository) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            ShoppingCart cart = command.Cart;

            await _repository.StoreBasket(cart,cancellationToken).ConfigureAwait(false);


            return new StoreBasketResult(command.Cart.UserName);
        }
    }
}
