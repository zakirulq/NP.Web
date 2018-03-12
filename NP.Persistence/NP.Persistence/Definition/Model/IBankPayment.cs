namespace NP.Persistence.Definition.Model
{
	interface IBankPayment : IPayment
	{
		IBankAccount BankAccount { get; set; }
	}
}
