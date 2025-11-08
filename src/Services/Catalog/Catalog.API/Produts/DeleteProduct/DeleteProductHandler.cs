
namespace Catalog.API.Produts.DeleteProduct
{
    public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;

    public record DeleteProductResult(bool IsSuccess);
    internal class DeleteProductCommandHandler(IDocumentSession session) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(request.Id, cancellationToken);
            if (product is null)
            {
                throw new ProductNotFoundException(request.Id);
            }
            session.Delete(product);
            await session.SaveChangesAsync(cancellationToken);
            return new DeleteProductResult(true);
        }
    }
}
