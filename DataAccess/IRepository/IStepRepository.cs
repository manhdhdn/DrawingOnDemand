using BusinessObject.Entities;

namespace DataAccess.IRepository
{
    public interface IStepRepository
    {
        public List<Step> GetSteps();
        public Step GetStep(Guid id);
        public void PutStep(Step step);
        public void PostStep(Step step);
        public void DeleteStep(Step step);
    }
}
