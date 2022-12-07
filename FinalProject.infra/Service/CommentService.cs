using FinalProject.core.Data;
using FinalProject.core.Repository;
using FinalProject.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.infra.Service
{
    public class CommentService : IService<Comment>
    {
        private readonly IRepository<Comment> _Repository;



        public CommentService(IRepository<Comment> Repository)
        {
            _Repository = Repository;
        }

        public void Create(Comment t)
        {
             _Repository.Create(t);
        }

        public void Delete(int id)
        {
            _Repository.Delete(id);
        }

        public List<Comment> GetAll()
        {
            return _Repository.GetAll();
        }

        public Comment GetById(int id)
        {
            return _Repository.GetById(id);
        }

        public void Update(Comment t)
        {
            _Repository.Update(t);
        }
    }
}
