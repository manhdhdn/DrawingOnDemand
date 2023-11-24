using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Certificate
    {
        public Guid Id { get; set; }
        public string Image { get; set; } = null!;
        public DateTime AchievedDate { get; set; }
        public string? Description { get; set; }
        public Guid? AccountId { get; set; }

        public virtual Account? Account { get; set; }
    }
}
