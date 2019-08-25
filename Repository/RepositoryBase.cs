using Dapper.Contrib.Extensions;
using ExampleDapperPostgreSQL.Contracts;
using ExampleDapperPostgreSQL.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;

namespace ExampleDapperPostgreSQL.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        protected readonly IConfiguration _ConnectionString;

        public RepositoryBase(IConfiguration config)
        {
            _ConnectionString = config;
        }
        
        public NpgsqlConnection GetConnection()
        {
            NpgsqlConnection connection = new NpgsqlConnection(_ConnectionString.GetConnectionString("PersonBase"));
            return connection;
        }

        public bool Delete(int id)
        {
            using (var db = GetConnection())
            {
                try
                {
                    var entity = GetById(id);
                    if (entity == null) throw new Exception("Registro Não Encontrado");

                    return db.Delete(entity);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (var db = GetConnection())
            {
                return db.GetAll<TEntity>();
            }
        }

        public TEntity GetById(int id)
        {
            try
            {
                using (var db = GetConnection())
                {
                    return db.Get<TEntity>(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Insert(ref TEntity entity)
        {
            try
            {
                using (var db = GetConnection())
                {
                     db.Insert(entity);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                using (var db = GetConnection())
                {
                    return db.Update(entity);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
