using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Payment
    {
        public Guid Id { get; set; }
        public string TransactionId { get; set; } = null!;
        public string Signature { get; set; } = null!;
        public string? TranferContent { get; set; }
        public string Status { get; set; } = null!;
        public Guid? OrderId { get; set; }

        public virtual Order? Order { get; set; }
    }
}
