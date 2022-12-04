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
    public class HomeRepository : IRepository<Homef>
    {
        private readonly IDbContext _dbContext;
        public HomeRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Homef t)
        {
            var p = new DynamicParameters();
            p.Add("welcomeiamge", t.Welcome_Iamge, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("descriptionf_", t.Description_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("phone_", t.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("email_", t.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("location_", t.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Home_Package.CreateHome", p, commandType: CommandType.StoredProcedure);

        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();

            p.Add("homeID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Home_Package.DeleteHome", p, commandType: CommandType.StoredProcedure);

        }

        public List<Homef> GetAll()
        {
            IEnumerable<Homef> result = _dbContext.Connection.Query<Homef>("Home_Package.GetAll", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Homef GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("homeID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Homef> result = _dbContext.Connection.Query<Homef>("Home_Package.GetById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(Homef t)
        {
            var p = new DynamicParameters();

            p.Add("ID", t.Home_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("image", t.Welcome_Iamge, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("descriptionf", t.Description_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("phone_", t.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("email_", t.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("location_", t.Location, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Home_Package.UpdateHome", p, commandType: CommandType.StoredProcedure);
        }

       

        




    }
}
