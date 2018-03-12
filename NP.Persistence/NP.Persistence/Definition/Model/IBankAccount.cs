namespace NP.Persistence.Definition.Model
{
	public interface IBankAccount
	{
		int BSB { get; set; }
		int AccountNumber { get; set; }
		string AccountName { get; set; }
	}
}
