using System.Text;
using Microsoft.AspNetCore.Mvc;
using MyUrlShorteningService.Api.Models;
using MyUrlShorteningService.Api.Services.Url;

namespace MyUrlShorteningService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UrlController: ControllerBase
{
    private readonly IUrlService _urlService;

    public UrlController(IUrlService urlService)
    {
        _urlService = urlService;
    }
    
    [HttpPost("shorten", Name = "ShortenUrl")]
    public async Task<IActionResult> ShortenUrl([FromBody] string url)
    {
        var shortUrl = await _urlService.ShortenUrlAsync(url);
        var serverUrl = $"{Request.Scheme}://{Request.Host}/{shortUrl}";
        return Ok(new ResponseDataModel()
        {
            Data = serverUrl,
            Message = "Url shortened successfully"
        });
    }

    [HttpPost("custom", Name = "CustomUrl")]
    
    public async Task<IActionResult> CustomUrl([FromBody] CustomUrlModel customUrlModel)
    {
        try
        {
            var shortUrl = await _urlService.CustomUrlAsync(customUrlModel.Url, customUrlModel.CustomUrl);
            var serverUrl = $"{Request.Scheme}://{Request.Host}/{shortUrl}";
            return Ok(new ResponseDataModel()
            {
                Data = serverUrl,
                Message = "Url shortened successfully"
            });
        }
        catch (UrlAlreadyExistsException ex)
        {
            return BadRequest(new ResponseDataModel()
            {
                Success = false,
                Message = $"{customUrlModel.CustomUrl} is already created. Please use another short code"
            });
        }
    }
}
