using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.core.Data
{
    public partial class Rolef
    {
        public Rolef()
        {
            Loginfs = new HashSet<Loginf>();
        }

        public decimal Id { get; set; }
        public string Role_Name { get; set; }

        public virtual ICollection<Loginf> Loginfs { get; set; }
    }
}
