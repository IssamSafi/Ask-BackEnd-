using FinalProject.core.Data;
using FinalProject.core.Repository;
using FinalProject.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.infra.Service
{
    public class TestmonialService : IService<Testimonialf>
    {
        private readonly IRepository<Testimonialf> _Repository;



        public TestmonialService(IRepository<Testimonialf> Repository)
        {
            _Repository = Repository;
        }

        public void Create(Testimonialf t)
        {
            _Repository.Create(t);
        }

        public void Delete(int id)
        {
            _Repository.Delete(id);
        }

        public List<Testimonialf> GetAll()
        {
            return _Repository.GetAll();
        }

        public Testimonialf GetById(int id)
        {
            return _Repository.GetById(id);
        }

        public void Update(Testimonialf t)
        {
            _Repository.Update(t);
        }
    }
}
