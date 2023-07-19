using WebApi.Models;

namespace WebApi.Context;

public interface IDbContext
{
	Task<IList<ResponseModel>> GetList();
}
