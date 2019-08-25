using ExampleDapperPostgreSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExampleDapperPostgreSQL.Contracts
{
    public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Insert(ref TEntity entity);
        bool Update(TEntity entity);
        bool Delete(Int32 id);
    }
}
