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
    public class RequirementsController : ODataController
    {
        private readonly IRequirementRepository repository = new RequirementRepository();

        // GET /OData/Requirements
        [EnableQuery]
        public IQueryable<Requirement> Get() => repository.GetRequirements().AsQueryable();

        // GET /OData/Requirements(5)
        [EnableQuery]
        public SingleResult<Requirement> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetRequirement(key) }.AsQueryable());

        // POST /OData/Requirements
        public IActionResult Post([FromBody] Requirement requirement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostRequirement(requirement);

            return Created(requirement);
        }

        // PUT /OData/Requirements(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] Requirement requirement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != requirement.Id)
            {
                return BadRequest();
            }

            var oldRequirement = repository.GetRequirement(key);

            if (oldRequirement == null)
            {
                return NotFound();
            }

            repository.PutRequirement(requirement);

            return Updated(requirement);
        }

        // PATCH /OData/Requirements(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<Requirement> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var requirement = repository.GetRequirement(key);

            if (requirement == null)
            {
                return NotFound();
            }

            delta.Patch(requirement);

            repository.PutRequirement(requirement);

            return Updated(requirement);
        }

        // DELETE /OData/Requirements(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var requirement = repository.GetRequirement(key);

            if (requirement == null)
            {
                return NotFound();
            }

            repository.DeleteRequirement(requirement);

            return NoContent();
        }
    }
}
