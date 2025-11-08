namespace Catalog.API.Produts.GetProduct
{
    public record  GetProductQuery(int? Pagenumber = 1, int? PageSize = 10) : IQurey<GetProductResult>;

    public record GetProductResult(IEnumerable<Product> Products);

    internal class GetProductQureyHandler(IDocumentSession session):IQureyHandler<GetProductQuery,GetProductResult>
    {
        public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>().ToPagedListAsync(query.Pagenumber ?? 1,query.PageSize ?? 10,cancellationToken);
            return new GetProductResult(products);
        }
    }
}
