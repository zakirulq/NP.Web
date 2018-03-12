using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NP.Web.Models
{
	public class BankPayment
	{
		public int BSB { get; set; }
		public int AccountNumber { get; set; }
		public string AccountName { get; set; }
		public string ReferenceNumber { get; set; }
		public double Amount { get; set; }
	}
}