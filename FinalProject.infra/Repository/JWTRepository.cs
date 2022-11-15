using Dapper;
using FinalProject.core.Common;
using FinalProject.core.Data;
using FinalProject.core.Repository;
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
    }
}
