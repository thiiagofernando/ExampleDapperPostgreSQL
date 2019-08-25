using Dapper.Contrib.Extensions;
using ExampleDapperPostgreSQL.ViewModels;
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
        public IEnumerable<PersonViewModel> ListPersonAll()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("PersonBase")))
            {
                return connection.GetAll<PersonViewModel>();
            }
        }
    }
}
