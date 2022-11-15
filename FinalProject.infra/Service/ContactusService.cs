using FinalProject.core.Data;
using FinalProject.core.Repository;
using FinalProject.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.infra.Service
{
    public class ContactusService : IService<Contactusf>
        {

            private readonly IRepository<Contactusf> _Repository;



            public ContactusService(IRepository<Contactusf> Repository)
            {
                _Repository = Repository;
            }
            public void Create(Contactusf t)
            {
                _Repository.Create(t);
            }

            public void Delete(int id)
            {
                _Repository.Delete(id);
            }

            public List<Contactusf> GetAll()
            {
                return _Repository.GetAll();
            }

            public Contactusf GetById(int id)
            {
                return _Repository.GetById(id);
            }

            public void Update(Contactusf t)
            {
                _Repository.Update(t);
            }
        }
    }

