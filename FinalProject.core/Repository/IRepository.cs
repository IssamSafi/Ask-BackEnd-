using FinalProject.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.core.Repository
{
    public interface IRepository <T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Create(T t);
        void Update(T t);
        void Delete(int id);
    }
}
