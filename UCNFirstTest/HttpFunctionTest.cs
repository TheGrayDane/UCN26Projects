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
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Hello World");
    }
}