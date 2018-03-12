using System;
using NP.Persistence.Model;
using NP.Persistence.Repositories;
using NP.Persistence.Definition.Repositories;

namespace NP.Persistence.Repository
{
	public class RepositoryBankPayment : Repository<BankPayment>, IRepositoryBankPayment
	{
		readonly IPersistenceContext _context;

		public RepositoryBankPayment(IPersistenceContext persistenceContext)
		{
			_context = persistenceContext;
		}

		public override bool Add(BankPayment entity)
		{
			var isSuccessful = false;
			try
			{
				var bankPayment = $"{entity.BankAccount.BSB}" +
						$",{entity.BankAccount.AccountNumber}" +
						$",{entity.BankAccount.AccountName}," +
						$"{entity.Reference}" +
						$",{entity.Amount}";

				_context.Set.Add(bankPayment);
				isSuccessful = true;
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return isSuccessful;
		}
	}
}
