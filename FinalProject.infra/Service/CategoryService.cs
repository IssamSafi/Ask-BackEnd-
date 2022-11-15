using FinalProject.core.Data;
using FinalProject.core.Repository;
using FinalProject.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.infra.Service
{
   public class CategoryService : IService<Categoryf>
    {
        private readonly IRepository<Categoryf> _Repository;



        public CategoryService(IRepository<Categoryf> Repository)
        {
            _Repository = Repository;
        }
    
public void Create(Categoryf t)
        {
            _Repository.Create(t);
        }

        public void Delete(int id)
        {
            _Repository.Delete(id);
        }

        public List<Categoryf> GetAll()
        {
            return _Repository.GetAll();
        }

        public Categoryf GetById(int id)
        {
            return _Repository.GetById(id);
        }

        public void Update(Categoryf t)
        {
            _Repository.Update(t);
        }
    }
}
