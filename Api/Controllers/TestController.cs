using Api.Context;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers;

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
	public void AddData([FromBody] ResponseModel model)
	{
		_logger.LogInformation("Logger model - {model}", JsonConvert.SerializeObject(model));
	}
	
	[HttpGet]
	[Route("FromQuery")]
	public string FromQuery([FromQuery] string query)
	{
		return $"Method FromQuery: query = {query}";
	}
	
	[HttpGet]
	[Route("FromRoute/{id}")]
	public string FromRoute([FromRoute] int id)
	{
		return $"Method FromRoute: id = {id}";
	}

	[HttpGet]
	[Route("GetData")]
	public async Task<IList<ResponseModel>> GetData()
	{
		return await _context.GetList();
	}
}
