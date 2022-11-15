using FinalProject.core.Data;
using FinalProject.core.Repository;
using FinalProject.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.infra.Service
{
    public class UserService : IService<Userf>
    {
        private readonly IRepository<Userf> _userRepository;



        public UserService(IRepository<Userf> userRepository)
        {
            _userRepository = userRepository;
        }

        public void Create(Userf t)
        {
            _userRepository.Create(t);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public List<Userf> GetAll()
        {
            return _userRepository.GetAll();
        }

        public Userf GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void Update(Userf t)
        {
            _userRepository.Update(t);
        }
    }
}
