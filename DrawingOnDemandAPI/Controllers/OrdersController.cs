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
    public class OrdersController : ODataController
    {
        private readonly IOrderRepository repository = new OrderRepository();

        // GET /OData/Orders
        [EnableQuery(MaxExpansionDepth = 3)]
        public IQueryable<Order> Get() => repository.GetOrders().AsQueryable();

        // GET /OData/Orders(5)
        [EnableQuery(MaxExpansionDepth = 3)]
        public SingleResult<Order> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetOrder(key) }.AsQueryable());

        // POST /OData/Orders
        public IActionResult Post([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostOrder(order);

            return Created(order);
        }

        // PUT /OData/Orders(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != order.Id)
            {
                return BadRequest();
            }

            var oldOrder = repository.GetOrder(key);

            if (oldOrder == null)
            {
                return NotFound();
            }

            repository.PutOrder(order);

            return Updated(order);
        }

        // PATCH /OData/Orders(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<Order> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = repository.GetOrder(key);

            if (order == null)
            {
                return NotFound();
            }

            delta.Patch(order);

            repository.PutOrder(order);

            return Updated(order);
        }

        // DELETE /OData/Orders(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = repository.GetOrder(key);

            if (order == null)
            {
                return NotFound();
            }

            repository.DeleteOrder(order);

            return NoContent();
        }
    }
}
