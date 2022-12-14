using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.core.Data
{
    public partial class Loginf
    {
        public decimal Id { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public decimal Role_Id { get; set; }
        public decimal? User_Id { get; set; }

        public virtual Rolef Role { get; set; }
        public virtual Userf User { get; set; }
    }
}
