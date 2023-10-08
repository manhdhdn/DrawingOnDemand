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
    public class ArtworksController : ODataController
    {
        private readonly IArtworkRepository repository = new ArtworkRepository();

        // GET /OData/Artworks
        [EnableQuery]
        public IQueryable<Artwork> Get() => repository.GetArtworks().AsQueryable();

        // GET /OData/Artworks(5)
        [EnableQuery]
        public SingleResult<Artwork> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetArtwork(key) }.AsQueryable());

        // POST /OData/Artworks
        public IActionResult Post([FromBody] Artwork artwork)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostArtwork(artwork);

            return Created(artwork);
        }

        // PUT /OData/Artworks(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] Artwork artwork)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != artwork.Id)
            {
                return BadRequest();
            }

            var oldArtwork = repository.GetArtwork(key);

            if (oldArtwork == null)
            {
                return NotFound();
            }

            repository.PutArtwork(artwork);

            return Updated(artwork);
        }

        // PATCH /OData/Artworks(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<Artwork> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var artwork = repository.GetArtwork(key);

            if (artwork == null)
            {
                return NotFound();
            }

            delta.Patch(artwork);

            repository.PutArtwork(artwork);

            return Updated(artwork);
        }

        // DELETE /OData/Artworks(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var artwork = repository.GetArtwork(key);

            if (artwork == null)
            {
                return NotFound();
            }

            repository.DeleteArtwork(artwork);

            return NoContent();
        }
    }
}
