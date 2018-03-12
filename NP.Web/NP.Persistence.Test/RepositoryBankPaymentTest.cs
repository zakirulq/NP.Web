using System;
using NUnit.Framework;
using NP.Persistence.Repository;
using NP.Persistence.PersistenceContext;
using NP.Persistence.Definition.Repositories;
using NP.Persistence.Model;

namespace NP.Persistence.Test
{
	[TestFixture]
	public class RepositoryBankPaymentTest
	{
		string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\\TestData.txt";
		IPersistenceContext context;
		RepositoryBankPayment repo;
		BankPayment payment;

		void InitializeTest()
		{
			context = new FilePersistenceContext(filePath);
			repo = new RepositoryBankPayment(context);

			payment = new BankPayment()
			{
				BankAccount = new BankAccount()
				{
					BSB = 123456,
					AccountNumber = 12345678,
					AccountName = "David"
				},
				Reference = "R01",
				Amount = 100
			};
		}

		[Test]
		public void TestBankPaymentAddedToContext()
		{
			InitializeTest();
			repo.Add(payment);
			Assert.AreEqual(1,repo.GetContextForTest().Set.Count);
		}

		[TestCase(123456, 12365478, "Smith", "REF02", 500.50,"123456,12365478,Smith,REF02,500.50")]
		public void TestBankPaymentAddedToContextInProperFormat(int bsb, int accountNumber, string name, string reference, double amount, 
			string expectedOutput)
		{
			InitializeTest();
			var paymentForSmith = new BankPayment()
			{
				BankAccount = new BankAccount()
				{
					BSB = bsb,
					AccountNumber = accountNumber,
					AccountName = name
				},
				Reference = reference,
				Amount = amount
			};
			repo.Add(paymentForSmith);
			Assert.AreEqual(expectedOutput, repo.GetContextForTest().Set[0]);
		}

		[TestCase(123456, 12365478, "Smith", "REF02", 500.5010, "123456,12365478,Smith,REF02,500.50")]
		[TestCase(123456, 12365478, "Smith", "REF02", 500.599, "123456,12365478,Smith,REF02,500.60")]
		public void TestBankPaymentAddedToContextConsideresUptoTwoDigits(int bsb, int accountNumber, string name, string reference, double amount,
			string expectedOutput)
		{
			InitializeTest();
			var paymentForSmith = new BankPayment()
			{
				BankAccount = new BankAccount()
				{
					BSB = bsb,
					AccountNumber = accountNumber,
					AccountName = name
				},
				Reference = reference,
				Amount = amount
			};
			repo.Add(paymentForSmith);
			Assert.AreEqual(expectedOutput, repo.GetContextForTest().Set[0]);
		}
	}
}
