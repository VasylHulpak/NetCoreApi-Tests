using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers;

[Route("/api/Test")]
public class TestController : ControllerBase
{
	private readonly ILogger<TestController> _logger;
	private readonly IDbContext _context;

	public TestController(ILogger<TestController> logger, IDbContext context)
	{
		_logger = logger;
		_context = context;
	}

	[HttpPost]
	[Route("AddData")]
	public void AddData(ResponseModel model)
	{
		_logger.LogInformation("Logger model - {model}", JsonConvert.SerializeObject(model));
	}

	[HttpGet]
	[Route("GetData")]
	public async Task<IList<ResponseModel>> GetData()
	{
		return await _context.GetList();
	}
}
