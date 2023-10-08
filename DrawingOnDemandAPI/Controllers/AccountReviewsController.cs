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
    public class AccountReviewsController : ODataController
    {
        private readonly IAccountReviewRepository repository = new AccountReviewRepository();

        // GET /OData/AccountReviews
        [EnableQuery]
        public IQueryable<AccountReview> Get() => repository.GetAccountReviews().AsQueryable();

        // GET /OData/AccountReviews(5)
        [EnableQuery]
        public SingleResult<AccountReview> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetAccountReview(key) }.AsQueryable());

        // POST /OData/AccountReviews
        public IActionResult Post([FromBody] AccountReview accountReview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostAccountReview(accountReview);

            return Created(accountReview);
        }

        // PUT /OData/AccountReviews(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] AccountReview accountReview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != accountReview.Id)
            {
                return BadRequest();
            }

            var oldAccountReview = repository.GetAccountReview(key);

            if (oldAccountReview == null)
            {
                return NotFound();
            }

            repository.PutAccountReview(accountReview);

            return Updated(accountReview);
        }

        // PATCH /OData/AccountReviews(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<AccountReview> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountReview = repository.GetAccountReview(key);

            if (accountReview == null)
            {
                return NotFound();
            }

            delta.Patch(accountReview);

            repository.PutAccountReview(accountReview);

            return Updated(accountReview);
        }

        // DELETE /OData/AccountReviews(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountReview = repository.GetAccountReview(key);

            if (accountReview == null)
            {
                return NotFound();
            }

            repository.DeleteAccountReview(accountReview);

            return NoContent();
        }
    }
}
