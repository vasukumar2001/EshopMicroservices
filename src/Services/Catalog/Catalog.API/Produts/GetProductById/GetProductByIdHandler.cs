
namespace Catalog.API.Produts.GetProductById
{
    public record GetProductByIdQurey(Guid Id) : IQurey<GetProductByIdResult>;

    public record GetProductByIdResult(Product Product);
    internal class GetProductByIdQureyHandler(IDocumentSession session)
        : IQureyHandler<GetProductByIdQurey, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQurey request, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(request.Id,cancellationToken);

            if (product is null) { 
                throw new ProductNotFoundException(request.Id);
            }
            return new GetProductByIdResult(product);
        }
    }
}
