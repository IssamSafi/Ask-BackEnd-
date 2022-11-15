using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.core.Data
{
    public partial class Testimonialf
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Messege { get; set; }
        public decimal? UserId { get; set; }

        public virtual Userf User { get; set; }
    }
}
