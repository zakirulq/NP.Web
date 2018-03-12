using System.Collections.Generic;
using NP.Persistence.Definition.Repositories;

namespace NP.Persistence.Repositories
{
	public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		public abstract bool Add(TEntity entity);

		protected List<string> BankPaments { get; set; }
	}
}
