using NP.Persistence.Definition.Model;

namespace NP.Persistence.Model
{
	public class BankAccount : IBankAccount
	{
		public int BSB { get; set; }
		public int AccountNumber { get; set; }
		public string AccountName { get; set; }
	}
}
