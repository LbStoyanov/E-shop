namespace Catalog.API.Products.GetProducts;


public record GetProductsQuery() : IQuery<GetProdustsResult>;

public record GetProdustsResult(IEnumerable<Product> Products);

internal class GetProductsQueryHandler (IDocumentSession session, ILogger<GetProductsQueryHandler> logger)
    : IQueryHandler<GetProductsQuery, GetProdustsResult>
{
    public async Task<GetProdustsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductsQueryHandler.Handle called with {@Query}", query);

        var products = await session.Query<Product>().ToListAsync(cancellationToken);

        return new GetProdustsResult(products);
    }
}

