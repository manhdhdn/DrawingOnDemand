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
    public class OrderDetailsController : ODataController
    {
        private readonly IOrderDetailRepository repository = new OrderDetailRepository();

        // GET /OData/OrderDetails
        [EnableQuery]
        public IQueryable<OrderDetail> Get() => repository.GetOrderDetails().AsQueryable();

        // GET /OData/OrderDetails(5)
        [EnableQuery]
        public SingleResult<OrderDetail> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetOrderDetail(key) }.AsQueryable());

        // POST /OData/OrderDetails
        public IActionResult Post([FromBody] OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostOrderDetail(orderDetail);

            return Created(orderDetail);
        }

        // PUT /OData/OrderDetails(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != orderDetail.Id)
            {
                return BadRequest();
            }

            var oldOrderDetail = repository.GetOrderDetail(key);

            if (oldOrderDetail == null)
            {
                return NotFound();
            }

            repository.PutOrderDetail(orderDetail);

            return Updated(orderDetail);
        }

        // PATCH /OData/OrderDetails(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<OrderDetail> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderDetail = repository.GetOrderDetail(key);

            if (orderDetail == null)
            {
                return NotFound();
            }

            delta.Patch(orderDetail);

            repository.PutOrderDetail(orderDetail);

            return Updated(orderDetail);
        }

        // DELETE /OData/OrderDetails(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderDetail = repository.GetOrderDetail(key);

            if (orderDetail == null)
            {
                return NotFound();
            }

            repository.DeleteOrderDetail(orderDetail);

            return NoContent();
        }
    }
}
