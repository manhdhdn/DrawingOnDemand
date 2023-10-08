using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Timeline
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Detail { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string Status { get; set; } = null!;
        public Guid RequirementId { get; set; }

        public virtual Requirement? Requirement { get; set; }
    }
}
