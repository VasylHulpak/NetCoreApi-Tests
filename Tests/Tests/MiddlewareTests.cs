using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using WebApi.Middlewares;

namespace Tests2.Tests;

[TestFixture]
public class MiddlewareTests
{
	private Mock<ILogger<LoggerMiddleware>>? _logger;
	private RequestDelegate? _requestDelegate;
	
	[SetUp]
	public void SetTup()
	{
		_requestDelegate = (_) => Task.FromResult(0);
		_logger = new Mock<ILogger<LoggerMiddleware>>();
	}
	
	[Test]
	public async Task RequestLoggerMiddleware()
	{
		// Arrange
		var defaultContext = new DefaultHttpContext
		{
			Request =
			{
				Path = "/api/test/"
			}
		};
		var message = $"Log current call {defaultContext.Request.Path}";

		// Act
		var middlewareInstance = new LoggerMiddleware(_requestDelegate!, _logger!.Object);
		await middlewareInstance.InvokeAsync(defaultContext);

		//Assert
		_logger.Verify(l =>
			l.Log(
				LogLevel.Information,
				It.IsAny<EventId>(),
				It.Is<It.IsAnyType>((state, type) => state!.ToString()!.Contains(message)),
				null, ((Func<object, Exception, string>)It.IsAny<object>())!
			));
	}
}
