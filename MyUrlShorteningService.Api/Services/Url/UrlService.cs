using MyUrlShorteningService.Api.Models;

namespace MyUrlShorteningService.Api.Services.Url;

public class UrlService:IUrlService
{
    private readonly Dictionary<string, string> _urlList;

    public UrlService()
    {
        _urlList = new Dictionary<string, string>();
    }
    public Task<string> ShortenUrlAsync(string url)
    {
        var code = GenerateUniqueCode();
        while (_urlList.ContainsKey(code))
        {
            code = GenerateUniqueCode();
        }
        _urlList.Add(code, url);
        return Task.FromResult(code);
    }

    public Task<string> GetUrlAsync(string shortUrl)
    {
        if (_urlList.TryGetValue(shortUrl, out var url))
        {
            return Task.FromResult(url);
        }
        throw new UrlNotFoundException();
    }

    public Task<string> CustomUrlAsync(string url, string customUrl)
    {
        if (_urlList.ContainsKey(customUrl))
        {
            throw new UrlAlreadyExistsException();
        }
        _urlList.Add(customUrl, url);
        return Task.FromResult(customUrl);
    }

    private string GenerateUniqueCode()
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var stringChars = new char[6];

        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[Random.Shared.Next(chars.Length)];
        }

        return new String(stringChars);
    }
}