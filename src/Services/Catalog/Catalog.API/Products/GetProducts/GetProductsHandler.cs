namespace Catalog.API.Products.GetProducts;


public record GetProductsQuery() : IQuery<GetProdustsResult>;

public record GetProdustsResult(IEnumerable<Product> Products);

internal class GetProductsQueryHandler (IDocumentSession session)
    : IQueryHandler<GetProductsQuery, GetProdustsResult>
{
    public async Task<GetProdustsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {

        var products = await session.Query<Product>().ToListAsync(cancellationToken);

        return new GetProdustsResult(products);
    }
}

