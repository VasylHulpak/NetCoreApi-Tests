using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using Api.Context;
using Api.Controllers;
using Api.Models;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace Tests2.Tests;

[TestFixture]
public class TestControllerTests
{
	private Mock<IDbContext>? _context;
	private TestController? _controller;
	private Mock<ILogger<TestController>>? _logger;
	private IList<ResponseModel>? _mockList;
	
	[SetUp]
	public void SetTup()
	{
		_mockList = new List<ResponseModel>
		{
			new ResponseModel() { Id = 1, Name = "test1" },
			new ResponseModel() { Id = 2, Name = "test2" },
		};
		
		_context = new Mock<IDbContext>();
		_context.Setup(m => m.GetList()).ReturnsAsync(_mockList);

		_logger = new Mock<ILogger<TestController>>();
		_controller = new TestController(_logger.Object, _context.Object);
	}

	[Test]
	public async Task GetData()
	{
		//arrange
		var actualResult = _mockList;

		//act
		var expectedResult = await _controller.GetData();

		//Assert
		Assert.AreEqual(actualResult.Count(), expectedResult.Count());
	}

	[Test]
	public void AddData()
	{
		//arrange
		var model = new ResponseModel
		{
			Id = 2,
			Name = "logger test example"
		};
		
		
		var message = $"Logger model - {JsonConvert.SerializeObject(model)}";

		//act
		_controller!.AddData(model);

		//Assert
		_logger.Verify(l =>
			l.Log(
				LogLevel.Information,
				It.IsAny<EventId>(),
				It.Is<It.IsAnyType>((state, type) => state.ToString().Contains(message)),
				null,
				(Func<object, Exception, string>)It.IsAny<object>()
			));
	}
}
