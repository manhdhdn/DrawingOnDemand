using BusinessObject.Entities;
using DataAccess.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace DrawingOnDemandAPI.Controllers
{
    [Authorize]
    public class PaymentsController : ODataController
    {
        private readonly IPaymentRepository repository = new PaymentRepository();

        // GET /OData/Payments
        [EnableQuery]
        public IQueryable<Payment> Get() => repository.GetPayments().AsQueryable();

        // GET /OData/Payments(5)
        [EnableQuery]
        public SingleResult<Payment> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetPayment(key) }.AsQueryable());

        // POST /OData/Payments
        public IActionResult Post([FromBody] Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostPayment(payment);

            return Created(payment);
        }

        // PUT /OData/Payments(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != payment.Id)
            {
                return BadRequest();
            }

            var oldPayment = repository.GetPayment(key);

            if (oldPayment == null)
            {
                return NotFound();
            }

            repository.PutPayment(payment);

            return Updated(payment);
        }

        // PATCH /OData/Payments(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<Payment> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var payment = repository.GetPayment(key);

            if (payment == null)
            {
                return NotFound();
            }

            delta.Patch(payment);

            repository.PutPayment(payment);

            return Updated(payment);
        }

        // DELETE /OData/Payments(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var payment = repository.GetPayment(key);

            if (payment == null)
            {
                return NotFound();
            }

            repository.DeletePayment(payment);

            return NoContent();
        }
    }
}
