using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class OrderDetail
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public double Free { get; set; }
        public Guid ArtworkId { get; set; }
        public Guid OrderId { get; set; }

        public virtual Artwork? Artwork { get; set; }
        public virtual Order? Order { get; set; }
    }
}
