using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.core.Data
{
    public partial class Likeanddislike
    {
        public decimal Id { get; set; }
        public decimal? Likee { get; set; }
        public decimal? Dislike { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Askid { get; set; }

        public virtual Asking Ask { get; set; }
        public virtual Userf User { get; set; }
    }
}
