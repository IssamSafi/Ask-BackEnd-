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
    public class UserRepository : IRepository<Userf>
    {
        private readonly IDbContext _dbContext;
        public UserRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Userf t)
        {
            var p = new DynamicParameters();
            p.Add("firstname", t.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("lastname", t.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Phone_", t.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("email_", t.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("image", t.ImagePath, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("User_Package.CreateUser", p, commandType: CommandType.StoredProcedure);

        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();

            p.Add("userID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("User_Package.DeleteUser", p, commandType: CommandType.StoredProcedure);

        }

        public List<Userf> GetAll()
        {
            IEnumerable<Userf> result = _dbContext.Connection.Query<Userf>("User_Package.GetAllUser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Userf GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("userID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Userf> result = _dbContext.Connection.Query<Userf>("User_Package.GetUserById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(Userf t)
        {
            var p = new DynamicParameters();

            p.Add("userID", t.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("firstname", t.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("lastname", t.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Phone_", t.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("email_", t.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("image", t.ImagePath, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("User_Package.UpdateUser", p, commandType: CommandType.StoredProcedure);
        }

      
    }
}
