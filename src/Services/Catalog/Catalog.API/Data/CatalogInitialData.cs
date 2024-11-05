using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if(await session.Query<Product>().AnyAsync())
            return;

        //Marten UPSERT will cater the existing records
        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync();
    }

    private IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>
    {
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Samsung Galaxy S24 Ultra",
            Description = "Some description for phone",
            ImageFile = "product-1.png",
            Price = 1989.99M,
            Category = new List<string>{"Smart Phone"}
        },
         new Product
        {
            Id = Guid.NewGuid(),
            Name = "Samsung Galaxy S23 Ultra",
            Description = "Some description for phone",
            ImageFile = "product-1.png",
            Price = 1989.99M,
            Category = new List<string>{"Smart Phone"}
        },
          new Product
        {
            Id = Guid.NewGuid(),
            Name = "Samsung Galaxy S22 Ultra",
            Description = "Some description for phone",
            ImageFile = "product-1.png",
            Price = 1989.99M,
            Category = new List<string>{"Smart Phone"}
        },
    };
}

