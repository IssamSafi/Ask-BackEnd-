using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.core.Data
{
    public partial class Categoryf
    {
        public Categoryf()
        {
            Askings = new HashSet<Asking>();
        }

        public decimal Id { get; set; }
        public string Category_Name { get; set; }
        public string Image_Path { get; set; }

        public virtual ICollection<Asking> Askings { get; set; }
    }
}
