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
    public class AccountRolesController : ODataController
    {
        private readonly IAccountRoleRepository repository = new AccountRoleRepository();

        // GET /OData/AccountRoles
        [EnableQuery]
        public IQueryable<AccountRole> Get() => repository.GetAccountRoles().AsQueryable();

        // GET /OData/AccountRoles(5)
        [EnableQuery]
        public SingleResult<AccountRole> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetAccountRole(key) }.AsQueryable());

        // POST /OData/AccountRoles
        public IActionResult Post([FromBody] AccountRole accountRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostAccountRole(accountRole);

            return Created(accountRole);
        }

        // PUT /OData/AccountRoles(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] AccountRole accountRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != accountRole.Id)
            {
                return BadRequest();
            }

            var oldAccountRole = repository.GetAccountRole(key);

            if (oldAccountRole == null)
            {
                return NotFound();
            }

            repository.PutAccountRole(accountRole);

            return Updated(accountRole);
        }

        // PATCH /OData/AccountRoles(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<AccountRole> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountRole = repository.GetAccountRole(key);

            if (accountRole == null)
            {
                return NotFound();
            }

            delta.Patch(accountRole);

            repository.PutAccountRole(accountRole);

            return Updated(accountRole);
        }

        // DELETE /OData/AccountRoles(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountRole = repository.GetAccountRole(key);

            if (accountRole == null)
            {
                return NotFound();
            }

            repository.DeleteAccountRole(accountRole);

            return NoContent();
        }
    }
}
