using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Material
    {
        public Material()
        {
            Artworks = new HashSet<Artwork>();
            Requirements = new HashSet<Requirement>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Artwork> Artworks { get; set; }
        public virtual ICollection<Requirement> Requirements { get; set; }
    }
}
