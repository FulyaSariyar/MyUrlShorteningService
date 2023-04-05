namespace MyUrlShorteningService.Api.Services.Url;

public interface IUrlService
{
    //url shortening method
    Task<string> ShortenUrlAsync(string url);
    //url redirecting method
    Task<string> GetUrlAsync(string shortUrl);
    //custom url method
    Task<string> CustomUrlAsync(string url, string customUrl);
}