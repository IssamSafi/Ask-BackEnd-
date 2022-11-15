using FinalProject.core.Data;
using FinalProject.core.Repository;
using FinalProject.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.infra.Service
{
    public class AboutusService : IService<Aboutusf>
    {

        private readonly IRepository<Aboutusf> _Repository;



        public AboutusService(IRepository<Aboutusf> Repository)
        {
            _Repository = Repository;
        }
        public void Create(Aboutusf t)
        {
            _Repository.Create(t);
        }

        public void Delete(int id)
        {
            _Repository.Delete(id);
        }

        public List<Aboutusf> GetAll()
        {
            return _Repository.GetAll();
        }

        public Aboutusf GetById(int id)
        {
            return _Repository.GetById(id);
        }

        public void Update(Aboutusf t)
        {
            _Repository.Update(t);
        }
    }
}
