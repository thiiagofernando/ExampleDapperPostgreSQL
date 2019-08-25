using Dapper;
using Dapper.Contrib.Extensions;
using ExampleDapperPostgreSQL.Contracts;
using ExampleDapperPostgreSQL.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace ExampleDapperPostgreSQL.Repository
{
    public class RepositoryBase : IRepositoryBase<Person>
    {
        protected readonly IConfiguration _ConnectionString;

        public RepositoryBase(IConfiguration config)
        {
            _ConnectionString = config;
        }

        public  IDbConnection GetConnection()
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

        public IEnumerable<Person> GetAll()
        {
            using (var db = GetConnection())
            {
                return db.GetAll<Person>();
            }
        }

        public Person GetById(int id)
        {
            try
            {
                using (var db = GetConnection())
                {
                    return db.Get<Person>(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Insert(Person person)
        {
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    db.Insert<Person>(person);
                }
            }
            catch (Exception ex)
            {
                var men = ex.Message;
                throw;
            }
        }

        public bool Update(Person person)
        {
            try
            {
                using (var db = GetConnection())
                {
                    return db.Update(person);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
