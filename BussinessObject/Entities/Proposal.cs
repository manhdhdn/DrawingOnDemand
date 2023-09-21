﻿using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Proposal
    {
        public Proposal()
        {
            Attackments = new HashSet<Attackment>();
        }

        public Guid Id { get; set; }
        public string Introduction { get; set; } = null!;
        public decimal Cost { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string Status { get; set; } = null!;
        public Guid RequirementId { get; set; }
        public Guid CreatedBy { get; set; }

        public virtual Account CreatedByNavigation { get; set; } = null!;
        public virtual Requirement Requirement { get; set; } = null!;
        public virtual ICollection<Attackment> Attackments { get; set; }
    }
}
