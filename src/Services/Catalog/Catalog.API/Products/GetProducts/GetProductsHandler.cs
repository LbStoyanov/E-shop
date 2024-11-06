namespace Catalog.API.Products.GetProducts;


public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProdustsResult>;

public record GetProdustsResult(IEnumerable<Product> Products);

internal class GetProductsQueryHandler(IDocumentSession session)
    : IQueryHandler<GetProductsQuery, GetProdustsResult>
{
    public async Task<GetProdustsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {

        var products = await session.Query<Product>().ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);

        return new GetProdustsResult(products);
    }
}

