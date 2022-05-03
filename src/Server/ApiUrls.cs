namespace CaseStudy.Server;

public static class ApiUrls
{
    public const string BaseUrl = "https://api.punkapi.com/v2/";
    public static string Beers => BaseUrl + "beers";
    public static string Beer(long index) => Beers + $"/{index}";
}
