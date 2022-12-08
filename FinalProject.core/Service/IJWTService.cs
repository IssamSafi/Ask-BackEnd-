using FinalProject.core.Data;
using FinalProject.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.core.Service
{
    public interface IJWTService
    {
        string Auth(Loginf login);
         List<Report> Reports();
        List<TotalUser> totalUser();

        List<Testmonial> testmonials();

        List<SearchUser> searchUsers(SearchUser t);


    }
}
