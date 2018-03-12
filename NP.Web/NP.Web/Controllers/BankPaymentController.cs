using System.Web;
using NP.Web.Models;
using System.Web.Http;
using NP.Persistence.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http.Description;
using NP.Persistence.PersistenceContext;
using NP.Persistence.Definition.UnitOfWork;

namespace NP.Web.Controllers
{
	public class BankPaymentController : ApiController
	{
		IUnitOfWork uow;
		public BankPaymentController()
		{
			var context = new FilePersistenceContext(HttpContext.Current.Server.MapPath("~/BankPayments/data.txt"));
			uow = new UnitOfWork(context);
		}

		// GET api/<controller>
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public string Get(int id)
		{
			return "value";
		}

		// POST api/Employee
		[ResponseType(typeof(BankPayment))]
		public IHttpActionResult Post(BankPayment bankPayment)
		{
			var payment = new Persistence.Model.BankPayment();
			payment.BankAccount.BSB = bankPayment.BSB;
			payment.BankAccount.AccountNumber = bankPayment.AccountNumber;
			payment.BankAccount.AccountName = bankPayment.AccountName;
			payment.Reference = bankPayment.ReferenceNumber;
			payment.Amount = bankPayment.Amount;

			uow.BankPayment.Add(payment);
			uow.Save();

			return CreatedAtRoute("DefaultApi", new { id = bankPayment.ReferenceNumber }, bankPayment);
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
		}
	}
}