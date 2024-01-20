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
    public class MaterialsController : ODataController
    {
        private readonly IMaterialRepository repository = new MaterialRepository();

        // GET /OData/Materials
        [EnableQuery]
        public IQueryable<Material> Get() => repository.GetMaterials().AsQueryable();

        // GET /OData/Materials(5)
        [EnableQuery]
        public SingleResult<Material> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetMaterial(key) }.AsQueryable());

        // POST /OData/Materials
        public IActionResult Post([FromBody] Material accountReview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostMaterial(accountReview);

            return Created(accountReview);
        }

        // PUT /OData/Materials(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] Material accountReview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != accountReview.Id)
            {
                return BadRequest();
            }

            var oldMaterial = repository.GetMaterial(key);

            if (oldMaterial == null)
            {
                return NotFound();
            }

            repository.PutMaterial(accountReview);

            return Updated(accountReview);
        }

        // PATCH /OData/Materials(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<Material> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountReview = repository.GetMaterial(key);

            if (accountReview == null)
            {
                return NotFound();
            }

            delta.Patch(accountReview);

            repository.PutMaterial(accountReview);

            return Updated(accountReview);
        }

        // DELETE /OData/Materials(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountReview = repository.GetMaterial(key);

            if (accountReview == null)
            {
                return NotFound();
            }

            repository.DeleteMaterial(accountReview);

            return NoContent();
        }
    }
}
