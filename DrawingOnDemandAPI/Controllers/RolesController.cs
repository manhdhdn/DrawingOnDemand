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
    public class RolesController : ODataController
    {
        private readonly IRoleRepository repository = new RoleRepository();

        // GET /OData/Roles
        [EnableQuery]
        public IQueryable<Role> Get() => repository.GetRoles().AsQueryable();

        // GET /OData/Roles(5)
        [EnableQuery]
        public SingleResult<Role> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetRole(key) }.AsQueryable());

        // POST /OData/Roles
        public IActionResult Post([FromBody] Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostRole(role);

            return Created(role);
        }

        // PUT /OData/Roles(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != role.Id)
            {
                return BadRequest();
            }

            var oldRole = repository.GetRole(key);

            if (oldRole == null)
            {
                return NotFound();
            }

            repository.PutRole(role);

            return Updated(role);
        }

        // PATCH /OData/Roles(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<Role> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = repository.GetRole(key);

            if (role == null)
            {
                return NotFound();
            }

            delta.Patch(role);

            repository.PutRole(role);

            return Updated(role);
        }

        // DELETE /OData/Roles(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = repository.GetRole(key);

            if (role == null)
            {
                return NotFound();
            }

            repository.DeleteRole(role);

            return NoContent();
        }
    }
}
