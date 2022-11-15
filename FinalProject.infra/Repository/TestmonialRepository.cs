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
    public class TestmonialRepository :IRepository<Testimonialf>
    {
        private readonly IDbContext _dbContext;
    public TestmonialRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;


    }

        public void Create(Testimonialf t)
        {
            var p = new DynamicParameters();
            p.Add("name_ ", t.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("messege_", t.Messege, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("testmonial_Package.CreateTestmonial", p, commandType: CommandType.StoredProcedure);

        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("TID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("testmonial_Package.DeleteTestmonial", p, commandType: CommandType.StoredProcedure);

        }

        public List<Testimonialf> GetAll()
        {
            IEnumerable<Testimonialf> result = _dbContext.Connection.Query<Testimonialf>("testmonial_Package.GetAllTestmonial", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Testimonialf GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("TID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Testimonialf> result = _dbContext.Connection.Query<Testimonialf>("testmonial_Package.GetById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(Testimonialf t)
        {
            var p = new DynamicParameters();

            p.Add("TID", t.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("name_ ", t.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("messege_", t.Messege, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("testmonial_Package.UpdateTestmonial", p, commandType: CommandType.StoredProcedure);
        }
    }
}
