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
    public class SurfacesController : ODataController
    {
        private readonly ISurfaceRepository repository = new SurfaceRepository();

        // GET /OData/Surfaces
        [EnableQuery]
        public IQueryable<Surface> Get() => repository.GetSurfaces().AsQueryable();

        // GET /OData/Surfaces(5)
        [EnableQuery]
        public SingleResult<Surface> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetSurface(key) }.AsQueryable());

        // POST /OData/Surfaces
        public IActionResult Post([FromBody] Surface surface)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostSurface(surface);

            return Created(surface);
        }

        // PUT /OData/Surfaces(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] Surface surface)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != surface.Id)
            {
                return BadRequest();
            }

            var oldSurface = repository.GetSurface(key);

            if (oldSurface == null)
            {
                return NotFound();
            }

            repository.PutSurface(surface);

            return Updated(surface);
        }

        // PATCH /OData/Surfaces(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<Surface> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var surface = repository.GetSurface(key);

            if (surface == null)
            {
                return NotFound();
            }

            delta.Patch(surface);

            repository.PutSurface(surface);

            return Updated(surface);
        }

        // DELETE /OData/Surfaces(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var surface = repository.GetSurface(key);

            if (surface == null)
            {
                return NotFound();
            }

            repository.DeleteSurface(surface);

            return NoContent();
        }
    }
}
