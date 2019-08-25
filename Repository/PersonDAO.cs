using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;

namespace ExampleDapperPostgreSQL.Models
{
    public class PersonDAO
    {
        private IConfiguration _configuration;
        public PersonDAO(IConfiguration config)
        {
            _configuration = config;
        }
        public IEnumerable<Person> ListPersonAll()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("PersonBase")))
            {
                return connection.GetAll<Person>();
            }
        }
    }
}
