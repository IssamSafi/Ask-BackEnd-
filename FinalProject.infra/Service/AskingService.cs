using FinalProject.core.Data;
using FinalProject.core.Repository;
using FinalProject.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.infra.Service
{
    public class AskingService : IService<Asking>
    {
        private readonly IRepository<Asking> _Repository;



        public AskingService(IRepository<Asking> Repository)
        {
            _Repository = Repository;
        }

        public void Create(Asking t)
        {
            _Repository.Create(t);
        }

        public void Delete(int id)
        {
            _Repository.Delete(id);
        }

        public List<Asking> GetAll()
        {
           return _Repository.GetAll();
        }

        public Asking GetById(int id)
        {
            return _Repository.GetById(id);
        }

        public void Update(Asking t)
        {
            _Repository.Update(t);
        }
    }
}
