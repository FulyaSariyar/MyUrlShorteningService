namespace MyUrlShorteningService.Api.Models;

public class ResponseDataModel
{
    public string Message { get; set; } = "Ok";
    public object Data { get; set; }
    public bool Success { get; set; } = true;
    public DateTime ResponseTime { get; set; } = DateTime.UtcNow;
}