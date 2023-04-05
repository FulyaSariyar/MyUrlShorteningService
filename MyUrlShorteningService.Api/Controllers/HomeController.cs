using Microsoft.AspNetCore.Mvc;
using MyUrlShorteningService.Api.Models;
using MyUrlShorteningService.Api.Services.Url;

namespace MyUrlShorteningService.Api.Controllers;

public class HomeController : Controller
{
    private readonly IUrlService _urlService;

    public HomeController(IUrlService urlService)
    {
        _urlService = urlService;
    }

    [HttpGet("{shortUrl}", Name = "/")]
    public async Task<IActionResult> GetUrl(string shortUrl)
    {
        try
        {
            var url = await _urlService.GetUrlAsync(shortUrl);
            return Redirect(url);
        }
        catch (UrlNotFoundException ex)
        {
            return NotFound($"{shortUrl}'url code not found");
        }
    }
}