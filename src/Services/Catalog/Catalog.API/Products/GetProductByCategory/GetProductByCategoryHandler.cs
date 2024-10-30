
namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategryResult>;

public record GetProductByCategryResult(IEnumerable<Product> Products);

internal class GetProductByCategoryQueryHandler (IDocumentSession session)
    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategryResult>
{
    public async Task<GetProductByCategryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {

        var products = await session.Query<Product>()
            .Where(p => p.Category.Contains(query.Category))
            .ToListAsync();

        return new GetProductByCategryResult(products);
    }
}

