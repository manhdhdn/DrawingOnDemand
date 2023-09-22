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
    public class ArtsController : ODataController
    {
        private readonly IArtRepository repository = new ArtRepository();

        // GET /OData/Arts
        [EnableQuery]
        public IQueryable<Art> Get() => repository.GetArts().AsQueryable();

        // GET /OData/Arts(5)
        [EnableQuery]
        public SingleResult<Art> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetArt(key) }.AsQueryable());

        // POST /OData/Arts
        public IActionResult Post([FromBody] Art art)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostArt(art);

            return Created(art);
        }

        // PUT /OData/Arts(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] Art art)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != art.Id)
            {
                return BadRequest();
            }

            var oldArt = repository.GetArt(key);

            if (oldArt == null)
            {
                return NotFound();
            }

            repository.PutArt(art);

            return Updated(art);
        }

        // PATCH /OData/Arts(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<Art> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var art = repository.GetArt(key);

            if (art == null)
            {
                return NotFound();
            }

            delta.Patch(art);

            repository.PutArt(art);

            return Updated(art);
        }

        // DELETE /OData/Arts(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var art = repository.GetArt(key);

            if (art == null)
            {
                return NotFound();
            }

            repository.DeleteArt(art);

            return NoContent();
        }
    }
}
