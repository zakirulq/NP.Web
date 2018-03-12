namespace NP.Persistence.Definition.Model
{
	public interface IPayment
	{
		string Reference { get; set; }
		double Amount { get; set; }
	}
}
