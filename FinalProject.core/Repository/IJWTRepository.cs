﻿using FinalProject.core.Data;
using FinalProject.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.core.Repository
{
    public interface IJWTRepository
    {
        Loginf Auth(Loginf login);
        List<Report> Reports();
        List<newReportdata> newreport(); 
        List<TotalUser>  totalUser();
        List<Testmonial> testmonials();
        List<SearchUser> searchUsers(String search);

        List<AllUserSearch> allUserSearches();
        List<Chart> charts();
        List<CommentNumcs> commentNumcs();

        void Rigesters(Rigester register);

        List<Comments> comments();
        List<LikeCount> likeCounts();


    }
}
