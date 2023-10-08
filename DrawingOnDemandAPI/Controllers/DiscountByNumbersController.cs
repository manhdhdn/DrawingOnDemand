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
    public class DiscountByNumbersController : ODataController
    {
        private readonly IDiscountByNumberRepository repository = new DiscountByNumberRepository();

        // GET /OData/DiscountByNumbers
        [EnableQuery]
        public IQueryable<DiscountByNumber> Get() => repository.GetDiscountByNumbers().AsQueryable();

        // GET /OData/DiscountByNumbers(5)
        [EnableQuery]
        public SingleResult<DiscountByNumber> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetDiscountByNumber(key) }.AsQueryable());

        // POST /OData/DiscountByNumbers
        public IActionResult Post([FromBody] DiscountByNumber discountByNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostDiscountByNumber(discountByNumber);

            return Created(discountByNumber);
        }

        // PUT /OData/DiscountByNumbers(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] DiscountByNumber discountByNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != discountByNumber.Id)
            {
                return BadRequest();
            }

            var oldDiscountByNumber = repository.GetDiscountByNumber(key);

            if (oldDiscountByNumber == null)
            {
                return NotFound();
            }

            repository.PutDiscountByNumber(discountByNumber);

            return Updated(discountByNumber);
        }

        // PATCH /OData/DiscountByNumbers(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<DiscountByNumber> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var discountByNumber = repository.GetDiscountByNumber(key);

            if (discountByNumber == null)
            {
                return NotFound();
            }

            delta.Patch(discountByNumber);

            repository.PutDiscountByNumber(discountByNumber);

            return Updated(discountByNumber);
        }

        // DELETE /OData/DiscountByNumbers(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var discountByNumber = repository.GetDiscountByNumber(key);

            if (discountByNumber == null)
            {
                return NotFound();
            }

            repository.DeleteDiscountByNumber(discountByNumber);

            return NoContent();
        }
    }
}
