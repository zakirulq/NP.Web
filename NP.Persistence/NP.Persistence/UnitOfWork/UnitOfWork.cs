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
			BankPayment = new RepositoryBankPayment(context);
		}

		public IRepositoryBankPayment BankPayment { get; }

		public void Save()
		{
			_context.Save();
		}
	}
}
