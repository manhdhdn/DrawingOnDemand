﻿using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Size
    {
        public Size()
        {
            Requirements = new HashSet<Requirement>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public double Width { get; set; }
        public double Length { get; set; }

        public virtual ICollection<Requirement> Requirements { get; set; }
    }
}
