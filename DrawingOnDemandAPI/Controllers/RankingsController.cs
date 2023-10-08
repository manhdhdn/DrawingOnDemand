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
    public class RankingsController : ODataController
    {
        private readonly IRankingRepository repository = new RankingRepository();

        // GET /OData/Rankings
        [EnableQuery]
        public IQueryable<Ranking> Get() => repository.GetRankings().AsQueryable();

        // GET /OData/Rankings(5)
        [EnableQuery]
        public SingleResult<Ranking> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetRanking(key) }.AsQueryable());

        // POST /OData/Rankings
        public IActionResult Post([FromBody] Ranking ranking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostRanking(ranking);

            return Created(ranking);
        }

        // PUT /OData/Rankings(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] Ranking ranking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != ranking.Id)
            {
                return BadRequest();
            }

            var oldRanking = repository.GetRanking(key);

            if (oldRanking == null)
            {
                return NotFound();
            }

            repository.PutRanking(ranking);

            return Updated(ranking);
        }

        // PATCH /OData/Rankings(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<Ranking> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ranking = repository.GetRanking(key);

            if (ranking == null)
            {
                return NotFound();
            }

            delta.Patch(ranking);

            repository.PutRanking(ranking);

            return Updated(ranking);
        }

        // DELETE /OData/Rankings(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ranking = repository.GetRanking(key);

            if (ranking == null)
            {
                return NotFound();
            }

            repository.DeleteRanking(ranking);

            return NoContent();
        }
    }
}
