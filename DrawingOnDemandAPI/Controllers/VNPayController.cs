using DrawingOnDemandAPI.VNPay;
using DrawingOnDemandAPI.VNPay.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace DrawingOnDemandAPI.Controllers
{
    [Authorize]
    public class VNPayController : ODataController
    {
        public IActionResult Post([FromBody] VNPayRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Created(Payment.Send(request, HttpContext));
        }
    }
}
