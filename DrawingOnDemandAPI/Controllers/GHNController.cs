using DrawingOnDemandAPI.GHN;
using DrawingOnDemandAPI.GHN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace DrawingOnDemandAPI.Controllers
{
    public class GHNController : ODataController
    {
        public async Task<IActionResult> PostAsync([FromBody] GHNRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Created(await Order.Send(request));
        }

    }
}
