using FinalProject.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller<T> : ControllerBase where T:class
    {
        private readonly IService<T> _Service;


        public Controller(IService<T> Service)
        {
            _Service = Service;
        }

        [HttpPost]
        public void Create(T t)
        {
            _Service.Create(t);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _Service.Delete(id);
        }

        [HttpGet]
        public List<T> GetAll()
        {
            return _Service.GetAll();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public T GetById(int id)
        {
            return _Service.GetById(id);
        }

        [HttpPut]
        public void Update(T t)
        {
            _Service.Update(t);
        }
    }
}
