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
    public class FeesController : ODataController
    {
        private readonly IFeeRepository repository = new FeeRepository();

        // GET /OData/Fees
        [EnableQuery]
        public IQueryable<Fee> Get() => repository.GetFees().AsQueryable();

        // GET /OData/Fees(5)
        [EnableQuery]
        public SingleResult<Fee> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetFee(key) }.AsQueryable());

        // POST /OData/Fees
        public IActionResult Post([FromBody] Fee fee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostFee(fee);

            return Created(fee);
        }

        // PUT /OData/Fees(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] Fee fee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != fee.Id)
            {
                return BadRequest();
            }

            var oldFee = repository.GetFee(key);

            if (oldFee == null)
            {
                return NotFound();
            }

            repository.PutFee(fee);

            return Updated(fee);
        }

        // PATCH /OData/Fees(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<Fee> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fee = repository.GetFee(key);

            if (fee == null)
            {
                return NotFound();
            }

            delta.Patch(fee);

            repository.PutFee(fee);

            return Updated(fee);
        }

        // DELETE /OData/Fees(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fee = repository.GetFee(key);

            if (fee == null)
            {
                return NotFound();
            }

            repository.DeleteFee(fee);

            return NoContent();
        }
    }
}
