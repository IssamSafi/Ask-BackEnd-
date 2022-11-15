using FinalProject.core.Data;
using FinalProject.core.Repository;
using FinalProject.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.infra.Service
{
    public class CommonQuestionService : IService<CommonQuestion>
    {
        private readonly IRepository<CommonQuestion> _Repository;



        public CommonQuestionService(IRepository<CommonQuestion> Repository)
        {
            _Repository = Repository;
        }

        public void Create(CommonQuestion t)
        {
            _Repository.Create(t);
        }

        public void Delete(int id)
        {
            _Repository.Delete(id);
        }

        public List<CommonQuestion> GetAll()
        {
           return _Repository.GetAll();
        }

        public CommonQuestion GetById(int id)
        {
            return _Repository.GetById(id);
        }

        public void Update(CommonQuestion t)
        {
            _Repository.Update(t);
        }
    }
}
