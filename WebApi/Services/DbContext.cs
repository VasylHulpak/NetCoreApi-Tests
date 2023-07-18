using WebApi.Models;

namespace WebApi.Services;

public class DbContext : IDbContext
{

	public IEnumerable<ResponseModel> GetList()
	{
		return new List<ResponseModel>()
		{
			new ResponseModel() { Id = 1, Name = "test1" },
			new ResponseModel() { Id = 3, Name = "test3" },
		};
	}
}
