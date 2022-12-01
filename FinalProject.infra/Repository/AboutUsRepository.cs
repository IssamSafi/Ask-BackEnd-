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
    public class AboutUsRepository : IRepository<Aboutusf>
    {
        private readonly IDbContext _dbContext;
        public AboutUsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Aboutusf t)
        {
            var p = new DynamicParameters();
            p.Add("image_", t.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("descriptionf_", t.Description_, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Aboutus_Package.CreateAboutus", p, commandType: CommandType.StoredProcedure);

        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();

            p.Add("AboutusID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Aboutus_Package.DeleteAboutus", p, commandType: CommandType.StoredProcedure);

        }

        public List<Aboutusf> GetAll()
        {
            IEnumerable<Aboutusf> result = _dbContext.Connection.Query<Aboutusf>("Aboutus_Package.GetAll", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Aboutusf GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("AboutusID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Aboutusf> result = _dbContext.Connection.Query<Aboutusf>("Aboutus_Package.GetById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(Aboutusf t)
        {
            var p = new DynamicParameters();

            p.Add("AboutusID", t.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("image_", t.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("descriptionf", t.Description_, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Aboutus_Package.UpdateAboutus", p, commandType: CommandType.StoredProcedure);
        }
    }
}
