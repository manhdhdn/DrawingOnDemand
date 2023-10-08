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
    public class DiscountBySpecialsController : ODataController
    {
        private readonly IDiscountBySpecialRepository repository = new DiscountBySpecialRepository();

        // GET /OData/DiscountBySpecials
        [EnableQuery]
        public IQueryable<DiscountBySpecial> Get() => repository.GetDiscountBySpecials().AsQueryable();

        // GET /OData/DiscountBySpecials(5)
        [EnableQuery]
        public SingleResult<DiscountBySpecial> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetDiscountBySpecial(key) }.AsQueryable());

        // POST /OData/DiscountBySpecials
        public IActionResult Post([FromBody] DiscountBySpecial discountBySpecial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostDiscountBySpecial(discountBySpecial);

            return Created(discountBySpecial);
        }

        // PUT /OData/DiscountBySpecials(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] DiscountBySpecial discountBySpecial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != discountBySpecial.Id)
            {
                return BadRequest();
            }

            var oldDiscountBySpecial = repository.GetDiscountBySpecial(key);

            if (oldDiscountBySpecial == null)
            {
                return NotFound();
            }

            repository.PutDiscountBySpecial(discountBySpecial);

            return Updated(discountBySpecial);
        }

        // PATCH /OData/DiscountBySpecials(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<DiscountBySpecial> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var discountBySpecial = repository.GetDiscountBySpecial(key);

            if (discountBySpecial == null)
            {
                return NotFound();
            }

            delta.Patch(discountBySpecial);

            repository.PutDiscountBySpecial(discountBySpecial);

            return Updated(discountBySpecial);
        }

        // DELETE /OData/DiscountBySpecials(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var discountBySpecial = repository.GetDiscountBySpecial(key);

            if (discountBySpecial == null)
            {
                return NotFound();
            }

            repository.DeleteDiscountBySpecial(discountBySpecial);

            return NoContent();
        }
    }
}
