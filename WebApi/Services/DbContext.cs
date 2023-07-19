using WebApi.Models;

namespace WebApi.Services;

public class DbContext : IDbContext
{
	public async Task<IList<ResponseModel>> GetList()
	{
		return new List<ResponseModel>()
		{
			new ResponseModel() { Id = 1, Name = "test1" },
			new ResponseModel() { Id = 3, Name = "test3" },
		};
	}
}
