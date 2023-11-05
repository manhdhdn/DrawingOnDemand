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
    public class InvitesController : ODataController
    {
        private readonly IInviteRepository repository = new InviteRepository();

        // GET /OData/Invites
        [EnableQuery]
        public IQueryable<Invite> Get() => repository.GetInvites().AsQueryable();

        // GET /ODataInvites(5)
        [EnableQuery]
        public SingleResult<Invite> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetInvite(key) }.AsQueryable());

        // POST /OData/Invites
        public IActionResult Post([FromBody] Invite invite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostInvite(invite);

            return Created(invite);
        }

        // PUT /OData/Invitets(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] Invite invite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != invite.Id)
            {
                return BadRequest();
            }

            var oldInvite = repository.GetInvite(key);

            if (oldInvite == null)
            {
                return NotFound();
            }

            repository.PutInvite(invite);

            return Updated(invite);
        }

        // PATCH /OData/Invites(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<Invite> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var invite = repository.GetInvite(key);

            if (invite == null)
            {
                return NotFound();
            }

            delta.Patch(invite);

            repository.PutInvite(invite);

            return Updated(invite);
        }

        // DELETE /OData/Invites(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var invite = repository.GetInvite(key);

            if (invite == null)
            {
                return NotFound();
            }

            repository.DeleteInvite(invite);

            return NoContent();
        }
    }
}
