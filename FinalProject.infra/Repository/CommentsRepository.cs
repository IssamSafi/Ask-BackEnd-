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
    public class CommentsRepository : IRepository<Comment>
    {
        private readonly IDbContext _dbContext;
        public CommentsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Comment t)
        {
            var p = new DynamicParameters();
            p.Add("Comnt", t.Commentt, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("User_id", t.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("ask_id", t.Askid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Comment_Package.CreateComment", p, commandType: CommandType.StoredProcedure);

        }

    


        public void Delete(int id)
        {
            var p = new DynamicParameters();

            p.Add("CID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Comment_Package.DeleteComment", p, commandType: CommandType.StoredProcedure);

        }

        public List<Comment> GetAll()
        {
            IEnumerable<Comment> result = _dbContext.Connection.Query<Comment>("Comment_Package.GetAll", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Comment GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("CID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Comment> result = _dbContext.Connection.Query<Comment>("Comment_Package.GetById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(Comment t)
        {
            var p = new DynamicParameters();

            p.Add("CID", t.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Comnt", t.Commentt, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Comment_Package.UpdateComment", p, commandType: CommandType.StoredProcedure);
        }

   
    }
}

