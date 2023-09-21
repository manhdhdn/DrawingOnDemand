using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class HandOver
    {
        public HandOver()
        {
            HandOverItems = new HashSet<HandOverItem>();
        }

        public Guid Id { get; set; }
        public string? Notification { get; set; }
        public DateTime HandOverDate { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public string Status { get; set; } = null!;
        public Guid OrderId { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual ICollection<HandOverItem> HandOverItems { get; set; }
    }
}
