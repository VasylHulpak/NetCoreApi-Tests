﻿using Api.Models;

namespace Api.Context;

/// <summary>
/// Interface IDbContext.
/// </summary>
public interface IDbContext
{
	/// <summary>
	/// Method to get all list.
	/// </summary>
	/// <returns></returns>
	Task<IList<ResponseModel>> GetList();
}
