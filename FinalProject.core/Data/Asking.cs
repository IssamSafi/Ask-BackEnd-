using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.core.Data
{
    public partial class Asking
    {
        public decimal Id { get; set; }
        public decimal Itsapprove { get; set; }
        public string Messege { get; set; }
        public decimal? User_Id { get; set; }
        public DateTime? Askingdate { get; set; }

        public virtual Userf User { get; set; }
    }
}
