using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class HandOverItem
    {
        public Guid Id { get; set; }
        public string? HandOverId { get; set; }
        public Guid? OrderDetailId { get; set; }

        public virtual HandOver? HandOver { get; set; }
        public virtual OrderDetail? OrderDetail { get; set; }
    }
}
