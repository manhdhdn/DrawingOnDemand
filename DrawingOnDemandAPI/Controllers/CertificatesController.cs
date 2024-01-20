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
    public class CertificatesController : ODataController
    {
        private readonly ICertificateRepository repository = new CertificateRepository();

        // GET /OData/Certificates
        [EnableQuery]
        public IQueryable<Certificate> Get() => repository.GetCertificates().AsQueryable();

        // GET /OData/Certificates(5)
        [EnableQuery]
        public SingleResult<Certificate> Get([FromRoute] Guid key) => SingleResult.Create(new[] { repository.GetCertificate(key) }.AsQueryable());

        // POST /OData/Certificates
        public IActionResult Post([FromBody] Certificate certificate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostCertificate(certificate);

            return Created(certificate);
        }

        // PUT /OData/Certificates(5)
        public IActionResult Put([FromRoute] Guid key, [FromBody] Certificate certificate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != certificate.Id)
            {
                return BadRequest();
            }

            var oldCertificate = repository.GetCertificate(key);

            if (oldCertificate == null)
            {
                return NotFound();
            }

            repository.PutCertificate(certificate);

            return Updated(certificate);
        }

        // PATCH /OData/Certificates(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] Guid key, Delta<Certificate> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var certificate = repository.GetCertificate(key);

            if (certificate == null)
            {
                return NotFound();
            }

            delta.Patch(certificate);

            repository.PutCertificate(certificate);

            return Updated(certificate);
        }

        // DELETE /OData/Certificates(5)
        public IActionResult Delete([FromRoute] Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var certificate = repository.GetCertificate(key);

            if (certificate == null)
            {
                return NotFound();
            }

            repository.DeleteCertificate(certificate);

            return NoContent();
        }
    }
}
