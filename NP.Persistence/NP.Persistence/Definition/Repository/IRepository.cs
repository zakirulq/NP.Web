using System;

namespace NP.Persistence.Definition.Repositories
{
	public interface IRepository<TEntity> where TEntity : class
	{
		bool Add(TEntity entity);
	}
}
