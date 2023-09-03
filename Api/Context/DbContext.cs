using Api.Models;

namespace Api.Context;

public class DbContext : IDbContext
{
	public Task<IList<ResponseModel>> GetList()
	{
		return Task.FromResult<IList<ResponseModel>>(new List<ResponseModel>()
		{
			new ResponseModel() { Id = 1, Name = "test1" },
			new ResponseModel() { Id = 3, Name = "test3" },
		});
	}
}
