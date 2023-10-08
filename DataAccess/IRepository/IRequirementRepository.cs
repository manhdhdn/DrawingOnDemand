using BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IRequirementRepository
    {
        public List<Requirement> GetRequirements();
        public Requirement GetRequirement(Guid id);
        public void PutRequirement(Requirement requirement);
        public void PostRequirement(Requirement requirement);
        public void DeleteRequirement(Requirement requirement);
    }
}
