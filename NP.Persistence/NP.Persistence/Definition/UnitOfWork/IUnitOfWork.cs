using NP.Persistence.Definition.Repositories;

namespace NP.Persistence.Definition.UnitOfWork
{
	public interface IUnitOfWork
	{
		IRepositoryBankPayment BankPayment { get; }
		void Save();
	}
}
