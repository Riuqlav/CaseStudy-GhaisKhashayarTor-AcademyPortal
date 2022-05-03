using CaseStudy.Server.Repository;
using CaseStudy.Shared;

internal class BeerDBSeeder
{
    public BeerDBSeeder(IRepository<Beer> repository)
    {
        Repository = repository;
    }

    public IRepository<Beer> Repository { get; }

    internal async Task Seed()
    {
        if ((await Repository.GetAllAsync()).Any())
        {
            return;
        }

        using (var client = new HttpClient())
        {
            var beers = await client.GetFromJsonAsync<List<Beer>>("https://api.punkapi.com/v2/beers");
            if (beers == null)
            {
                return;
            }

            await Repository.CreateManyAsync(beers);
        }
    }
}