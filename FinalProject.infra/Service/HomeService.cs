using FinalProject.core.Data;
using FinalProject.core.Repository;
using FinalProject.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.infra.Service
{
    public class HomeService : IService<Homef>
    {
        private readonly IRepository<Homef> _Repository;



        public HomeService(IRepository<Homef> Repository)
        {
            _Repository = Repository;
        }

        public void Create(Homef t)
        {
            _Repository.Create(t);
        }

        public void Delete(int id)
        {
            _Repository.Delete(id);
        }

        public List<Homef> GetAll()
        {
            return _Repository.GetAll();
        }

        public Homef GetById(int id)
        {
            return _Repository.GetById(id);
        }

        public void Update(Homef t)
        {
            _Repository.Update(t);
        }
    }
}
