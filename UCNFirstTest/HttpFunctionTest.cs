using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace UCNFirstTest;

public class HttpFunctionTest
{
    private readonly ILogger<HttpFunctionTest> _logger;

    public HttpFunctionTest(ILogger<HttpFunctionTest> logger)
    {
        _logger = logger;
    }

    [Function("HttpFunctionTest")]
    [QueueOutput("test-queue", Connection = "Int-queue")]
    public Envelope Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        var envelope = new Envelope
        {
            Id = 1,
            Message = "Hello World"
        };
        _logger.LogInformation("C# HTTP trigger function should return an envelope.");
        return envelope;
    }

}

public class Envelope
{
    public int Id { get; set; }
    public string Message { get; set; }
}