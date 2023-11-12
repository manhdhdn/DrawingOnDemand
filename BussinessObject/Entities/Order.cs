using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Order
    {
        public Order()
        {
            HandOvers = new HashSet<HandOver>();
            OrderDetails = new HashSet<OrderDetail>();
            Payments = new HashSet<Payment>();
        }

        public Guid Id { get; set; }
        public string OrderType { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public DateTime? DepositDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public double Fee { get; set; }
        public string Status { get; set; } = null!;
        public decimal Total { get; set; }
        public Guid Orderedby { get; set; }
        public Guid DiscountId { get; set; }

        public virtual Discount? Discount { get; set; }
        public virtual Account? OrderedbyNavigation { get; set; } 
        public virtual ICollection<HandOver> HandOvers { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
