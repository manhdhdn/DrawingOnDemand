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
    public class SizesController : ODataController
    {
        private readonly ISizeRepository repository = new SizeRepository();

        // GET /OData/Sizes
        [EnableQuery]
        public IQueryable<Size> Get() => repository.GetSizes().AsQueryable();

        // GET /OData/Sizes(5)
        [EnableQuery]
        public SingleResult<Size> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetSize(key) }.AsQueryable());

        // POST /OData/Sizes
        public IActionResult Post([FromBody] Size size)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostSize(size);

            return Created(size);
        }

        // PUT /OData/Sizes(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] Size size)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != size.Id)
            {
                return BadRequest();
            }

            var oldSize = repository.GetSize(key);

            if (oldSize == null)
            {
                return NotFound();
            }

            repository.PutSize(size);

            return Updated(size);
        }

        // PATCH /OData/Sizes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<Size> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var size = repository.GetSize(key);

            if (size == null)
            {
                return NotFound();
            }

            delta.Patch(size);

            repository.PutSize(size);

            return Updated(size);
        }

        // DELETE /OData/Sizes(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var size = repository.GetSize(key);

            if (size == null)
            {
                return NotFound();
            }

            repository.DeleteSize(size);

            return NoContent();
        }
    }
}
