using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.core.DTO
{
    public class Report
    {
   
        public string Fname { get; set; }
     
        public string Lname { get; set; }
        public decimal? Itsapprove { get; set; }
        public string Image_Path { get; set; }
        public decimal Id { get; set; }
        public string Category_Name { get; set; }
        public decimal? User_Id { get; set; }
        public DateTime? Askingdate { get; set; }
        public decimal? Category_Id { get; set; }
        public string Messege { get; set; }
        public decimal Likee { get; set; }
        public decimal Dislike { get; set; }

    }
}
