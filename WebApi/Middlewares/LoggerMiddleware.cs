namespace WebApi.Middlewares;

public class LoggerMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<LoggerMiddleware> _logger;
	
	public LoggerMiddleware(RequestDelegate next, ILogger<LoggerMiddleware> logger)
	{
		_next = next;
		_logger = logger;
	}
	
	public async Task InvokeAsync(HttpContext context)
	{
		if (context.Request.Path.HasValue && context.Request.Path.Value.StartsWith("/api/"))
		{
			_logger.LogInformation("Log current call {url}", context.Request.Path.Value);
		}

		await _next(context);
	}
}
