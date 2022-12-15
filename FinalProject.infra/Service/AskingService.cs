using FinalProject.core.Data;
using FinalProject.core.Repository;
using FinalProject.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.infra.Service
{
    public class AskingService : IService<Asking>, IService<Likeanddislike>
    {
        private readonly IRepository<Asking> _Repository;
        private readonly IRepository<Likeanddislike> _Repositorylike;


        public AskingService(IRepository<Asking> Repository, IRepository<Likeanddislike> Repositorylike)
        {
            _Repository = Repository;
            _Repositorylike = Repositorylike;

        }

        public void Create(Asking t)
        {
            _Repository.Create(t);
        }

        public void Create(Likeanddislike t)
        {
            _Repositorylike.Create(t);
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

        public void Update(Likeanddislike t)
        {
            _Repositorylike.Update(t);
        }

        List<Likeanddislike> IService<Likeanddislike>.GetAll()
        {
            return _Repositorylike.GetAll();
        }

        Likeanddislike IService<Likeanddislike>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
