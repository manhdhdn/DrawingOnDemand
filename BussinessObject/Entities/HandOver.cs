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

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string PickupAddress { get; set; } = null!;
        public string ReceiveAddress { get; set; } = null!;
        public decimal ShipmentPrice { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public DateTime HandOverDate { get; set; }
        public string Status { get; set; } = null!;
        public Guid? OrderId { get; set; }

        public virtual Order? Order { get; set; }
        public virtual ICollection<HandOverItem> HandOverItems { get; set; }
    }
}
