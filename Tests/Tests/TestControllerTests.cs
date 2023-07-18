using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using WebApi.Controllers;
using WebApi.Models;
using WebApi.Services;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace Tests2.Tests;

[TestFixture]
public class TestControllerTests
{
	private Mock<IDbContext>? _context;
	private TestController? _controller;
	private Mock<ILogger<TestController>>? _logger;
	
	[SetUp]
	public void SetTup()
	{
		_context = new Mock<IDbContext>();
		_context.Setup(m => m.GetList()).Returns(new List<ResponseModel>
		{
			new ResponseModel() { Id = 1, Name = "test1" },
			new ResponseModel() { Id = 2, Name = "test2" },
		});

		_logger = new Mock<ILogger<TestController>>();
		_controller = new TestController(_logger.Object, _context.Object);
	}

	[Test]
	public void GetData()
	{
		//arrange
		var actualResult = new List<ResponseModel>
		{
			new ResponseModel() { Id = 1, Name = "test1" },
			new ResponseModel() { Id = 2, Name = "test2" },
		};

		//act
		var expectedResult = _controller.GetData();

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
