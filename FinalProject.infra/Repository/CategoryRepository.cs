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
    public class CategoryRepository : IRepository<Categoryf>
    {
        private readonly IDbContext _dbContext;
        public CategoryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Categoryf t)
        {
            var p = new DynamicParameters();
            p.Add("cname", t.Category_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("image", t.Image_Path, dbType: DbType.String, direction: ParameterDirection.Input);



            _dbContext.Connection.Execute("Category_Package.CreateCategory", p, commandType: CommandType.StoredProcedure);

        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();

            p.Add("categoryID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Category_Package.DeleteCategory", p, commandType: CommandType.StoredProcedure);

        }

        public List<Categoryf> GetAll()
        {
            IEnumerable<Categoryf> result = _dbContext.Connection.Query<Categoryf>("Category_Package.GetAllCategory", commandType: CommandType.StoredProcedure);
            return result.ToList();


           
        }

        public Categoryf GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("categoryID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Categoryf> result = _dbContext.Connection.Query<Categoryf>("Category_Package.GetCategoryById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(Categoryf t)
        {
            var p = new DynamicParameters();

            p.Add("categoryID", t.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("cname", t.Category_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("image", t.Image_Path, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Category_Package.UpdateCategory", p, commandType: CommandType.StoredProcedure);
        }
    }
}
