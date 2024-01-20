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
    public class AccountsController : ODataController
    {
        private readonly IAccountRepository repository = new AccountRepository();

        // GET /OData/Accounts
        [EnableQuery]
        public IQueryable<Account> Get() => repository.GetAccounts().AsQueryable();

        // GET /OData/Accounts(5)
        [EnableQuery]
        public SingleResult<Account> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetAccount(key) }.AsQueryable());

        // POST /OData/Accounts
        public IActionResult Post([FromBody] Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostAccount(account);

            return Created(account);
        }

        // PUT /OData/Accounts(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != account.Id)
            {
                return BadRequest();
            }

            var oldAccount = repository.GetAccount(key);

            if (oldAccount == null)
            {
                return NotFound();
            }

            repository.PutAccount(account);

            return Updated(account);
        }

        // PATCH /OData/Accounts(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<Account> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = repository.GetAccount(key);

            if (account == null)
            {
                return NotFound();
            }

            delta.Patch(account);

            repository.PutAccount(account);

            return Updated(account);
        }

        // DELETE /OData/Accounts(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = repository.GetAccount(key);

            if (account == null)
            {
                return NotFound();
            }

            repository.DeleteAccount(account);

            return NoContent();
        }
    }
}
