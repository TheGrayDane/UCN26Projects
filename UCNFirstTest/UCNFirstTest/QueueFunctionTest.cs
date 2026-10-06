using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace UCNFirstTest;

public class QueueFunctionTest
{
    private readonly ILogger<QueueFunctionTest> _logger;

    public QueueFunctionTest(ILogger<QueueFunctionTest> logger)
    {
        _logger = logger;
    }

    [Function(nameof(QueueFunctionTest))]
    public void Run([QueueTrigger("myqueue-items", Connection = "Int-queue")] QueueMessage message)
    {
        _logger.LogInformation("C# Queue trigger function processed: {messageText}", message.MessageText);
    }
}