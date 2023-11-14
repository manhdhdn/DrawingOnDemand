using BusinessObject.Entities.Context;
using BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class CertificateDAO
    {
        public static List<Certificate> GetCertificates()
        {
            var listCertificate = new List<Certificate>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listCertificate = context.Certificates.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listCertificate;
        }

        public static Certificate FindCertificate(Guid id)
        {
            Certificate certificate = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                certificate = context.Certificates.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return certificate!;
        }

        public static void SaveCertificate(Certificate certificate)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Certificates.Add(certificate);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateCertificate(Certificate certificate)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(certificate).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteCertificate(Certificate certificate)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Certificates.Remove(certificate);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
