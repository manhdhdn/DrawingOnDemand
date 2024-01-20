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
    public class ArtworkReviewsController : ODataController
    {
        private readonly IArtworkReviewRepository repository = new ArtworkReviewRepository();

        // GET /OData/ArtworkReviews
        [EnableQuery]
        public IQueryable<ArtworkReview> Get() => repository.GetArtworkReviews().AsQueryable();

        // GET /OData/ArtworkReviews(5)
        [EnableQuery]
        public SingleResult<ArtworkReview> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetArtworkReview(key) }.AsQueryable());

        // POST /OData/ArtworkReviews
        public IActionResult Post([FromBody] ArtworkReview artworkReview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostArtworkReview(artworkReview);

            return Created(artworkReview);
        }

        // PUT /OData/ArtworkReviews(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] ArtworkReview artworkReview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != artworkReview.Id)
            {
                return BadRequest();
            }

            var oldArtworkReview = repository.GetArtworkReview(key);

            if (oldArtworkReview == null)
            {
                return NotFound();
            }

            repository.PutArtworkReview(artworkReview);

            return Updated(artworkReview);
        }

        // PATCH /OData/ArtworkReviews(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<ArtworkReview> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var artworkReview = repository.GetArtworkReview(key);

            if (artworkReview == null)
            {
                return NotFound();
            }

            delta.Patch(artworkReview);

            repository.PutArtworkReview(artworkReview);

            return Updated(artworkReview);
        }

        // DELETE /OData/ArtworkReviews(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var artworkReview = repository.GetArtworkReview(key);

            if (artworkReview == null)
            {
                return NotFound();
            }

            repository.DeleteArtworkReview(artworkReview);

            return NoContent();
        }
    }
}
