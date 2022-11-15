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
   public class ContactUsRepository : IRepository<Contactusf>
    {
        private readonly IDbContext _dbContext;
        public ContactUsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Contactusf t)
        {
            var p = new DynamicParameters();
            p.Add("phone_", t.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("email_", t.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("location_", t.Locationc, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("contactus_Package.Createcontactus", p, commandType: CommandType.StoredProcedure);

        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();

            p.Add("contactID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("contactus_Package.Deletecontactus", p, commandType: CommandType.StoredProcedure);

        }

        public List<Contactusf> GetAll()
        {
            IEnumerable<Contactusf> result = _dbContext.Connection.Query<Contactusf>("contactus_Package.GetAll", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Contactusf GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("contactID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Contactusf> result = _dbContext.Connection.Query<Contactusf>("contactus_Package.GetById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(Contactusf t)
        {
            var p = new DynamicParameters();

            p.Add("contactID", t.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("phone_", t.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("email_", t.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("location_", t.Locationc, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("contactus_Package.Updatecontactus", p, commandType: CommandType.StoredProcedure);
        }
    }
}
