using BusinessObject.Entities;
using DataAccess.DAO;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TimelineRepository : ITimelineRepository
    {
        public List<Timeline> GetTimelines() => TimelineDAO.GetTimelines();
        public Timeline GetTimeline(Guid id) => TimelineDAO.FindTimeline(id);
        public void PutTimeline(Timeline timeline) => TimelineDAO.UpdateTimeline(timeline);
        public void PostTimeline(Timeline timeline) => TimelineDAO.SaveTimeline(timeline);
        public void DeleteTimeline(Timeline timeline) => TimelineDAO.DeleteTimeline(timeline);
    }
}
