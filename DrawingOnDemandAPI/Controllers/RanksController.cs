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
    public class RanksController : ODataController
    {
        private readonly IRankRepository repository = new RankRepository();

        // GET /OData/Ranks
        [EnableQuery]
        public IQueryable<Rank> Get() => repository.GetRanks().AsQueryable();

        // GET /OData/Ranks(5)
        [EnableQuery]
        public SingleResult<Rank> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetRank(key) }.AsQueryable());

        // POST /OData/Ranks
        public IActionResult Post([FromBody] Rank rank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostRank(rank);

            return Created(rank);
        }

        // PUT /OData/Ranks(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] Rank rank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != rank.Id)
            {
                return BadRequest();
            }

            var oldRank = repository.GetRank(key);

            if (oldRank == null)
            {
                return NotFound();
            }

            repository.PutRank(rank);

            return Updated(rank);
        }

        // PATCH /OData/Ranks(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<Rank> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rank = repository.GetRank(key);

            if (rank == null)
            {
                return NotFound();
            }

            delta.Patch(rank);

            repository.PutRank(rank);

            return Updated(rank);
        }

        // DELETE /OData/Ranks(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rank = repository.GetRank(key);

            if (rank == null)
            {
                return NotFound();
            }

            repository.DeleteRank(rank);

            return NoContent();
        }
    }
}
