using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Art
    {
        public Guid Id { get; set; }
        public string Image { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public Guid? ArtworkId { get; set; }

        public virtual Artwork? Artwork { get; set; }
    }
}
