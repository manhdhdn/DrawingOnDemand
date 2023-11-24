using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Size
    {
        public Guid Id { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public Guid? RequirementId { get; set; }
        public Guid? ArtworkId { get; set; }

        public virtual Artwork? Artwork { get; set; }
        public virtual Requirement? Requirement { get; set; }
    }
}
