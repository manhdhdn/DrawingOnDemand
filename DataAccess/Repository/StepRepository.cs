using BusinessObject.Entities;
using DataAccess.DAO;
using DataAccess.IRepository;

namespace DataAccess.Repository
{
    public class StepRepository : IStepRepository
    {
        public List<Step> GetSteps() => StepDAO.GetSteps();
        public Step GetStep(Guid id) => StepDAO.FindStep(id);
        public void PutStep(Step step) => StepDAO.UpdateStep(step);
        public void PostStep(Step step) => StepDAO.SaveStep(step);
        public void DeleteStep(Step step) => StepDAO.DeleteStep(step);
    }
}
