using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class HandOverItem
    {
        public Guid Id { get; set; }
        public decimal ShipmentPrice { get; set; }
        public int Quantity { get; set; }
        public Guid HandOverId { get; set; }
        public Guid ArtworkId { get; set; }

        public virtual Artwork Artwork { get; set; } = null!;
        public virtual HandOver HandOver { get; set; } = null!;
    }
}
