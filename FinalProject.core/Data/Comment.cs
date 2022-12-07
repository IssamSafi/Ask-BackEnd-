using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.core.Data
{
    public partial class Comment
    {
        public decimal Id { get; set; }
        public string Commentt { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Askid { get; set; }

        public virtual Asking Ask { get; set; }
        public virtual Userf User { get; set; }
    }
}
