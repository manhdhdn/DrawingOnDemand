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
    public class AttackmentsController : ODataController
    {
        private readonly IAttackmentRepository repository = new AttackmentRepository();

        // GET /OData/Attackments
        [EnableQuery]
        public IQueryable<Attackment> Get() => repository.GetAttackments().AsQueryable();

        // GET /OData/Attackments(5)
        [EnableQuery]
        public SingleResult<Attackment> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetAttackment(key) }.AsQueryable());

        // POST /OData/Attackments
        public IActionResult Post([FromBody] Attackment attackment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostAttackment(attackment);

            return Created(attackment);
        }

        // PUT /OData/Attackments(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] Attackment attackment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != attackment.Id)
            {
                return BadRequest();
            }

            var oldAttackment = repository.GetAttackment(key);

            if (oldAttackment == null)
            {
                return NotFound();
            }

            repository.PutAttackment(attackment);

            return Updated(attackment);
        }

        // PATCH /OData/Attackments(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<Attackment> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var attackment = repository.GetAttackment(key);

            if (attackment == null)
            {
                return NotFound();
            }

            delta.Patch(attackment);

            repository.PutAttackment(attackment);

            return Updated(attackment);
        }

        // DELETE /OData/Attackments(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var attackment = repository.GetAttackment(key);

            if (attackment == null)
            {
                return NotFound();
            }

            repository.DeleteAttackment(attackment);

            return NoContent();
        }
    }
}
