using BusinessObject.Entities;
using DataAccess.DAO;
using DataAccess.IRepository;

namespace DataAccess.Repository
{
    public class CertificateRepository : ICertificateRepository
    {
        public List<Certificate> GetCertificates() => CertificateDAO.GetCertificates();
        public Certificate GetCertificate(Guid id) => CertificateDAO.FindCertificate(id);
        public void PutCertificate(Certificate certificate) => CertificateDAO.UpdateCertificate(certificate);
        public void PostCertificate(Certificate certificate) => CertificateDAO.SaveCertificate(certificate);
        public void DeleteCertificate(Certificate certificate) => CertificateDAO.DeleteCertificate(certificate);
    }
}
