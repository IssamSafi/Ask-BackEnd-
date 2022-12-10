using FinalProject.core.Data;
using FinalProject.core.DTO;
using FinalProject.core.Repository;
using FinalProject.core.Service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinalProject.infra.Service
{
    public class JWTService : IJWTService
    {

        private readonly IJWTRepository _Repository;



        public JWTService(IJWTRepository Repository)
        {
            _Repository = Repository;
        }

        public List<AllUserSearch> allUserSearches()
        {
            return _Repository.allUserSearches();
        }

        public string Auth(Loginf login)

        {
            var result = _Repository.Auth(login);
            if (result == null)
            {
                return null;
            }
            else
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                    {

             new Claim("Name", result.User_Name),
                new Claim("Role", result.Role_Id.ToString()),
                new Claim("ID", result.User_Id.ToString())
    };
                var tokeOptions = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddSeconds(10),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return tokenString;

            }


        }

        public List<Chart> charts()
        {
            return _Repository.charts();
        }

        public List<Report> Reports()
        {
           return _Repository.Reports();
        }

        public void Rigesters(Rigester register)
        {
             _Repository.Rigesters(register);
        }

        public List<SearchUser> searchUsers(String search)
        {
            return _Repository.searchUsers(search);
        }

        public List<Testmonial> testmonials()
        {
            return _Repository.testmonials();
        }

        public List<TotalUser>  totalUser()
        {
            return _Repository.totalUser();
        }

   
    }
}
