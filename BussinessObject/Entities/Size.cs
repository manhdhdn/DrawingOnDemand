using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Size
    {
        public Guid Id { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public Guid? RequirementId { get; set; }
        public Guid? ArtworkId { get; set; }

        public virtual Artwork? Artwork { get; set; }
        public virtual Requirement? Requirement { get; set; }
    }
}
