using BusinessObject.Entities;
using DataAccess.IRepository;
using DataAccess.Repository;
using DrawingOnDemandAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace DrawingOnDemandAPI.Controllers
{
    [Authorize]
    public class ProposalsController : ODataController
    {
        private readonly IProposalRepository repository = new ProposalRepository();

        // GET /OData/Proposals
        [EnableQuery]
        public IQueryable<Proposal> Get() => repository.GetProposals().AsQueryable();

        // GET /OData/Proposals(5)
        [EnableQuery]
        public SingleResult<Proposal> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetProposal(key) }.AsQueryable());

        // POST /OData/Proposals
        [ClaimRequirement("email", "Artist")]
        public IActionResult Post([FromBody] Proposal proposal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostProposal(proposal);

            return Created(proposal);
        }

        // PUT /OData/Proposals(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] Proposal proposal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != proposal.Id)
            {
                return BadRequest();
            }

            var oldProposal = repository.GetProposal(key);

            if (oldProposal == null)
            {
                return NotFound();
            }

            repository.PutProposal(proposal);

            return Updated(proposal);
        }

        // PATCH /OData/Proposals(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<Proposal> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var proposal = repository.GetProposal(key);

            if (proposal == null)
            {
                return NotFound();
            }

            delta.Patch(proposal);

            repository.PutProposal(proposal);

            return Updated(proposal);
        }

        // DELETE /OData/Proposals(5)
        [ClaimRequirement("email", "Artist")]
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var proposal = repository.GetProposal(key);

            if (proposal == null)
            {
                return NotFound();
            }

            repository.DeleteProposal(proposal);

            return NoContent();
        }
    }
}
