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
   public  class CommonQuestionRepository :IRepository<CommonQuestion>
    {
        private readonly IDbContext _dbContext;
    public CommonQuestionRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
public void Create(CommonQuestion t)
        {
            var p = new DynamicParameters();
            p.Add("Question_", t.Question, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("CommonQuestion_Package.CreateCommonQuestion", p, commandType: CommandType.StoredProcedure);

        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();

            p.Add("QuestionID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("CommonQuestion_Package.DeleteCommonQuestion", p, commandType: CommandType.StoredProcedure);

        }

        public List<CommonQuestion> GetAll()
        {
            IEnumerable<CommonQuestion> result = _dbContext.Connection.Query<CommonQuestion>("CommonQuestion_Package.GetAllQuestion", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public CommonQuestion GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("QuestionID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<CommonQuestion> result = _dbContext.Connection.Query<CommonQuestion>("CommonQuestion_Package.GetById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(CommonQuestion t)
        {
            var p = new DynamicParameters();

            p.Add("QuestionID", t.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Question_", t.Question, dbType: DbType.String, direction: ParameterDirection.Input);
          
            _dbContext.Connection.Execute("CommonQuestion_Package.UpdateCommonQuestion", p, commandType: CommandType.StoredProcedure);
        }
    }
}
