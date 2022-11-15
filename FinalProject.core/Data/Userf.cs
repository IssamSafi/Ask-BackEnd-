﻿using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.core.Data
{
    public partial class Userf
    {
        public Userf()
        {
            Askings = new HashSet<Asking>();
            Loginfs = new HashSet<Loginf>();
            Testimonialves = new HashSet<Testimonialf>();
        }

        public decimal Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }

        public virtual ICollection<Asking> Askings { get; set; }
        public virtual ICollection<Loginf> Loginfs { get; set; }
        public virtual ICollection<Testimonialf> Testimonialves { get; set; }
    }
}
