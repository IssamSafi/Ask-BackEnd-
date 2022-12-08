using Dapper;
using FinalProject.core.Common;
using FinalProject.core.Data;
using FinalProject.core.DTO;
using FinalProject.core.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FinalProject.infra.Repository
{
   public class JWTRepository : IJWTRepository
    {
        private readonly IDbContext _dbContext;
        public JWTRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Loginf Auth(Loginf login)
        {
            var p = new DynamicParameters();
            p.Add("UserNAME", login.User_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASS", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Loginf> result = _dbContext.Connection.Query<Loginf>("Login_Package.User_Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

   

        public List<Report> Reports()
        {
            IEnumerable<Report> result = _dbContext.Connection.Query<Report>("User_Package.Reportuser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void Rigesters(Rigester register)
        {
            var p = new DynamicParameters();
            p.Add("firstname", register.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("lastname", register.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Email", register.User_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASS ", register.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Login_Package.Rigister", p, commandType: CommandType.StoredProcedure);

        }

        public List<SearchUser> searchUsers(SearchUser search)
        {
            var p = new DynamicParameters();
            p.Add("firstname ", search.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<SearchUser>("User_Package.SearchUser", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Testmonial> testmonials()
        {
            IEnumerable<Testmonial> result = _dbContext.Connection.Query<Testmonial>("User_Package.ShowTestmonial", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

     

        List<TotalUser> IJWTRepository.totalUser()
        {
            IEnumerable<TotalUser> result = _dbContext.Connection.Query<TotalUser>("Login_Package.Total_User", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
