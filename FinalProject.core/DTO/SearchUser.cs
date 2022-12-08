using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.core.DTO
{
   public class SearchUser
    {

        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Image_Path { get; set; }
        public decimal Itsapprove { get; set; }
        public string Messege { get; set; }
        public DateTime? Askingdate { get; set; }
        public string Category_Name { get; set; }
        public string Commentt { get; set; }

    }
}
