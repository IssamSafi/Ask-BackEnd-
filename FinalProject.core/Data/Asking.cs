﻿using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.core.Data
{
    public partial class Asking
    {
        public Asking()
        {
            Comments = new HashSet<Comment>();
            Likeanddislikes = new HashSet<Likeanddislike>();
        }

        public decimal Id { get; set; }
        public decimal Itsapprove { get; set; }
        public string Messege { get; set; }
        public decimal? User_Id { get; set; }
        public DateTime? Askingdate { get; set; }
        public decimal? Category_Id { get; set; }
        public decimal Likee { get; set; }
        public decimal Dislike { get; set; }

        public virtual Categoryf Category { get; set; }
        public virtual Userf User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Likeanddislike> Likeanddislikes { get; set; }
    }
}
