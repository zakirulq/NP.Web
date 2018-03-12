using System.Collections.Generic;

namespace NP.Persistence.Definition.Repositories
{
	public interface IPersistenceContext
	{
		List<object> Set { get; set; }
		bool Save();
		bool Delete(object entity);
	}
}
