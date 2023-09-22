using BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface ITimelineRepository
    {
        public List<Timeline> GetTimelines();
        public Timeline GetTimeline(Guid id);
        public void PutTimeline(Timeline timeline);
        public void PostTimeline(Timeline timeline);
        public void DeleteTimeline(Timeline timeline);
    }
}
