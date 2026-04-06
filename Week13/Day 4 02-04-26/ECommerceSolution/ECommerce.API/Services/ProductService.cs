using Microsoft.Extensions.Caching.Distributed;

public class ProductService
{
    private readonly IDistributedCache _cache;

    public ProductService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<string> GetProducts()
    {
        var cached = await _cache.GetStringAsync("products");

        if (!string.IsNullOrEmpty(cached))
            return cached;

        var data = "Data from DB";

        await _cache.SetStringAsync("products", data,
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });

        return data;
    }
}