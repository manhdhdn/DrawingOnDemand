using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Category
    {
        public Category()
        {
            Artworks = new HashSet<Artwork>();
            Requirements = new HashSet<Requirement>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Artwork> Artworks { get; set; }
        public virtual ICollection<Requirement> Requirements { get; set; }
    }
}
