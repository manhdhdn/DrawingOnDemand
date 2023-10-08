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
    public class HandOversController : ODataController
    {
        private readonly IHandOverRepository repository = new HandOverRepository();

        // GET /OData/HandOvers
        [EnableQuery]
        public IQueryable<HandOver> Get() => repository.GetHandOvers().AsQueryable();

        // GET /OData/HandOvers(5)
        [EnableQuery]
        public SingleResult<HandOver> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetHandOver(key) }.AsQueryable());

        // POST /OData/HandOvers
        public IActionResult Post([FromBody] HandOver handOver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostHandOver(handOver);

            return Created(handOver);
        }

        // PUT /OData/HandOvers(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] HandOver handOver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != handOver.Id)
            {
                return BadRequest();
            }

            var oldHandOver = repository.GetHandOver(key);

            if (oldHandOver == null)
            {
                return NotFound();
            }

            repository.PutHandOver(handOver);

            return Updated(handOver);
        }

        // PATCH /OData/HandOvers(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<HandOver> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var handOver = repository.GetHandOver(key);

            if (handOver == null)
            {
                return NotFound();
            }

            delta.Patch(handOver);

            repository.PutHandOver(handOver);

            return Updated(handOver);
        }

        // DELETE /OData/Accounts(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var handOver = repository.GetHandOver(key);

            if (handOver == null)
            {
                return NotFound();
            }

            repository.DeleteHandOver(handOver);

            return NoContent();
        }
    }
}
