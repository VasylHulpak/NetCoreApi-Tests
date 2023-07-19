using WebApi.Models;

namespace WebApi.Services;

public interface IDbContext
{
	Task<IList<ResponseModel>> GetList();
}
