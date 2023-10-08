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
    public class TimelinesController : ODataController
    {
        private readonly ITimelineRepository repository = new TimelineRepository();

        // GET /OData/Timelines
        [EnableQuery]
        public IQueryable<Timeline> Get() => repository.GetTimelines().AsQueryable();

        // GET /OData/Timelines(5)
        [EnableQuery]
        public SingleResult<Timeline> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetTimeline(key) }.AsQueryable());

        // POST /OData/Timelines
        public IActionResult Post([FromBody] Timeline timeline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostTimeline(timeline);

            return Created(timeline);
        }

        // PUT /OData/Timelines(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] Timeline timeline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != timeline.Id)
            {
                return BadRequest();
            }

            var oldTimeline = repository.GetTimeline(key);

            if (oldTimeline == null)
            {
                return NotFound();
            }

            repository.PutTimeline(timeline);

            return Updated(timeline);
        }

        // PATCH /OData/Timelines(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<Timeline> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timeline = repository.GetTimeline(key);

            if (timeline == null)
            {
                return NotFound();
            }

            delta.Patch(timeline);

            repository.PutTimeline(timeline);

            return Updated(timeline);
        }

        // DELETE /OData/Timelines(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timeline = repository.GetTimeline(key);

            if (timeline == null)
            {
                return NotFound();
            }

            repository.DeleteTimeline(timeline);

            return NoContent();
        }
    }
}
