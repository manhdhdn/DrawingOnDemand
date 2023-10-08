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
    public class HandOverItemsController : ODataController
    {
        private readonly IHandOverItemRepository repository = new HandOverItemRepository();

        // GET /OData/HandOverItems
        [EnableQuery]
        public IQueryable<HandOverItem> Get() => repository.GetHandOverItems().AsQueryable();

        // GET /OData/HandOverItems(5)
        [EnableQuery]
        public SingleResult<HandOverItem> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetHandOverItem(key) }.AsQueryable());

        // POST /OData/HandOverItems
        public IActionResult Post([FromBody] HandOverItem handOverItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostHandOverItem(handOverItem);

            return Created(handOverItem);
        }

        // PUT /OData/HandOverItems(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] HandOverItem handOverItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != handOverItem.Id)
            {
                return BadRequest();
            }

            var oldHandOverItem = repository.GetHandOverItem(key);

            if (oldHandOverItem == null)
            {
                return NotFound();
            }

            repository.PutHandOverItem(handOverItem);

            return Updated(handOverItem);
        }

        // PATCH /OData/HandOverItems(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<HandOverItem> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var handOverItem = repository.GetHandOverItem(key);

            if (handOverItem == null)
            {
                return NotFound();
            }

            delta.Patch(handOverItem);

            repository.PutHandOverItem(handOverItem);

            return Updated(handOverItem);
        }

        // DELETE /OData/HandOverItems(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var handOverItem = repository.GetHandOverItem(key);

            if (handOverItem == null)
            {
                return NotFound();
            }

            repository.DeleteHandOverItem(handOverItem);

            return NoContent();
        }
    }
}
