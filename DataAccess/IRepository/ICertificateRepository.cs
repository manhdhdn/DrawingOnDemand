using BusinessObject.Entities;

namespace DataAccess.IRepository
{
    public interface ICertificateRepository
    {
        public List<Certificate> GetCertificates();
        public Certificate GetCertificate(Guid id);
        public void PutCertificate(Certificate certificate);
        public void PostCertificate(Certificate certificate);
        public void DeleteCertificate(Certificate certificate);
    }
}
