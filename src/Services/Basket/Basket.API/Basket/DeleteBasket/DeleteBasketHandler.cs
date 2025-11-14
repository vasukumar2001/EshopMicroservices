namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;

    public record DeleteBasketResult(bool IsSuccess);

    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");
        }
    }

    public class DeleteBasketHandler(IBasketRepository _repository):ICommandHandler<DeleteBasketCommand,DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            bool deleted = await _repository.DeleteBasket(command.UserName,cancellationToken).ConfigureAwait(false);

            return new DeleteBasketResult(deleted);
        }
    }
}
