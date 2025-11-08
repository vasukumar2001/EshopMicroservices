namespace Catalog.API.Produts.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category) : IQurey<GetProductByCategoryResult>;

    public record GetProductByCategoryResult(IEnumerable<Product> Products);
    internal class GetProductByCategoryHandler(IDocumentSession session)
        : IQureyHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>()
                                        .Where(p => p.Category.Contains(request.Category))
                                        .ToListAsync(cancellationToken);

            return new GetProductByCategoryResult(products);
        }
    }
}
