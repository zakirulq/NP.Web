using NP.Persistence.Definition.UnitOfWork;
using NP.Persistence.Definition.Repositories;
using NP.Persistence.Repository;

namespace NP.Persistence.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		readonly IPersistenceContext _context;

		public UnitOfWork(IPersistenceContext context)
		{
			_context = context;
			//BankPayment object creation need to be done by IOC container and inject like "context" to remove the dependency
			BankPayment = new RepositoryBankPayment(context);
		}

		public IRepositoryBankPayment BankPayment { get; }

		public void Save()
		{
			_context.Save();
		}
	}
}
