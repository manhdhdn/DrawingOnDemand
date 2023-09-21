using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class DiscountByNumber
    {
        public DiscountByNumber()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public int Number { get; set; }
        public double DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
