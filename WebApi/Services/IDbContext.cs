using WebApi.Models;

namespace WebApi.Services;

public interface IDbContext
{
	public IEnumerable<ResponseModel> GetList();
}
