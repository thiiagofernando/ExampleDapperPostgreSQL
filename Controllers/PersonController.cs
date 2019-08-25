using ExampleDapperPostgreSQL.Models;
using ExampleDapperPostgreSQL.Repository;
using ExampleDapperPostgreSQL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace ExampleDapperPostgreSQL.Controllers
{
    public class PersonController : Controller
    {
        private IConfiguration _configuration;
        RepositoryBase<PersonViewModel> repo;
        public PersonController(IConfiguration config)
        {
            _configuration = config;
            repo = new RepositoryBase<PersonViewModel>(_configuration);
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(repo.GetAll().ToList()); 
        }

        [HttpGet]
        public IActionResult NewPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewPerson(PersonViewModel person)
        {
            return View();
        }

    }
}