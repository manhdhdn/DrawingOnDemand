using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Attackment
    {
        public Guid Id { get; set; }
        public string Image { get; set; } = null!;
        public Guid ProposalId { get; set; }

        public virtual Proposal Proposal { get; set; } = null!;
    }
}
