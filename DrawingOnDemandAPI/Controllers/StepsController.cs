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
    public class StepsController : ODataController
    {
        private readonly IStepRepository repository = new StepRepository();

        // GET /OData/Steps
        [EnableQuery]
        public IQueryable<Step> Get() => repository.GetSteps().AsQueryable();

        // GET /OData/Steps(5)
        [EnableQuery]
        public SingleResult<Step> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetStep(key) }.AsQueryable());

        // POST /OData/Steps
        public IActionResult Post([FromBody] Step step)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostStep(step);

            return Created(step);
        }

        // PUT /OData/Steps(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] Step step)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != step.Id)
            {
                return BadRequest();
            }

            var oldStep = repository.GetStep(key);

            if (oldStep == null)
            {
                return NotFound();
            }

            repository.PutStep(step);

            return Updated(step);
        }

        // PATCH /OData/Steps(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<Step> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var step = repository.GetStep(key);

            if (step == null)
            {
                return NotFound();
            }

            delta.Patch(step);

            repository.PutStep(step);

            return Updated(step);
        }

        // DELETE /OData/Steps(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var step = repository.GetStep(key);

            if (step == null)
            {
                return NotFound();
            }

            repository.DeleteStep(step);

            return NoContent();
        }
    }
}
