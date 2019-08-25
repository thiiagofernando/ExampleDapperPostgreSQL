using ExampleDapperPostgreSQL.Models;
using System;
using System.Collections.Generic;

namespace ExampleDapperPostgreSQL.Contracts
{
    public interface IRepositoryBase<T> where T : Person
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        bool Update(T entity);
        bool Delete(Int32 id);
    }
}
