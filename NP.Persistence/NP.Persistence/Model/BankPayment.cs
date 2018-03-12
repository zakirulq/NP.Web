using NP.Persistence.Definition.Model;

namespace NP.Persistence.Model
{
	public class BankPayment : IBankPayment
	{
		public BankPayment()
		{
			BankAccount = new BankAccount();
		}
		public IBankAccount BankAccount { get; set; }
		public string Reference { get; set; }
		public double Amount { get; set; }
	}
}
