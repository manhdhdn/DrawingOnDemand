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
    public class CategoriesController : ODataController
    {
        private readonly ICategoryRepository repository = new CategoryRepository();

        // GET /OData/Categories
        [EnableQuery]
        public IQueryable<Category> Get() => repository.GetCategories().AsQueryable();

        // GET /OData/Categories(5)
        [EnableQuery]
        public SingleResult<Category> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetCategory(key) }.AsQueryable());

        // POST /OData/Categories
        public IActionResult Post([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostCategory(category);

            return Created(category);
        }

        // PUT /OData/Categories(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != category.Id)
            {
                return BadRequest();
            }

            var oldCategory = repository.GetCategory(key);

            if (oldCategory == null)
            {
                return NotFound();
            }

            repository.PutCategory(category);

            return Updated(category);
        }

        // PATCH /OData/Categories(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<Category> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = repository.GetCategory(key);

            if (category == null)
            {
                return NotFound();
            }

            delta.Patch(category);

            repository.PutCategory(category);

            return Updated(category);
        }

        // DELETE /OData/Categories(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = repository.GetCategory(key);

            if (category == null)
            {
                return NotFound();
            }

            repository.DeleteCategory(category);

            return NoContent();
        }
    }
}
