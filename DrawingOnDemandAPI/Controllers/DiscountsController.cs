using BusinessObject.Entities;
using DataAccess.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace DrawingOnDemandAPI.Controllers
{
    public class DiscountsController : ODataController
    {
        private readonly IDiscountRepository repository = new DiscountRepository();

        // GET /OData/Discounts
        [EnableQuery]
        public IQueryable<Discount> Get() => repository.GetDiscounts().AsQueryable();

        // GET /OData/Discounts(5)
        [EnableQuery]
        public SingleResult<Discount> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetDiscount(key) }.AsQueryable());

        // POST /OData/Discounts
        public IActionResult Post([FromBody] Discount discount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostDiscount(discount);

            return Created(discount);
        }

        // PUT /OData/Discounts(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] Discount discount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != discount.Id)
            {
                return BadRequest();
            }

            var oldDiscount = repository.GetDiscount(key);

            if (oldDiscount == null)
            {
                return NotFound();
            }

            repository.PutDiscount(discount);

            return Updated(discount);
        }

        // PATCH /OData/Discounts(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<Discount> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var discount = repository.GetDiscount(key);

            if (discount == null)
            {
                return NotFound();
            }

            delta.Patch(discount);

            repository.PutDiscount(discount);

            return Updated(discount);
        }

        // DELETE /OData/Discounts(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var discount = repository.GetDiscount(key);

            if (discount == null)
            {
                return NotFound();
            }

            repository.DeleteDiscount(discount);

            return NoContent();
        }
    }
}
