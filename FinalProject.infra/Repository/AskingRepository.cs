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
   public  class AskingRepository : IRepository<Asking>
    {
        private readonly IDbContext _dbContext;
        public AskingRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    
public void Create(Asking t)
        {
            var p = new DynamicParameters();
            p.Add("approve", t.Itsapprove, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("messege_", t.Messege, dbType: DbType.String, direction: ParameterDirection.Input);
           p.Add("Datee", t.Askingdate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("CatID", t.Category_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Askig_Package.CreateAskig", p, commandType: CommandType.StoredProcedure);

        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();

            p.Add("AskigID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Askig_Package.DeleteAskig", p, commandType: CommandType.StoredProcedure);

        }

        public List<Asking> GetAll()
        {
            IEnumerable<Asking> result = _dbContext.Connection.Query<Asking>("Askig_Package.GetAll", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Asking GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("AskigID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Asking> result = _dbContext.Connection.Query<Asking>("Askig_Package.GetById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(Asking t)
        {
            var p = new DynamicParameters();

            p.Add("AskigID", t.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("approve", t.Itsapprove, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("messege_", t.Messege, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Datee", t.Askingdate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("CatID", t.Category_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            _dbContext.Connection.Execute("Askig_Package.UpdateAskig", p, commandType: CommandType.StoredProcedure);
        }
    }
}
