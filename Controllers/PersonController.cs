using ExampleDapperPostgreSQL.Models;
using ExampleDapperPostgreSQL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace ExampleDapperPostgreSQL.Controllers
{
    public class PersonController : Controller
    {
        private IConfiguration _configuration;
        RepositoryBase repo;
        public PersonController(IConfiguration config)
        {
            _configuration = config;
            repo = new RepositoryBase(_configuration);
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
        [ValidateAntiForgeryToken]
        public IActionResult NewPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                repo.Insert(person);
                return RedirectToAction("Index","Person");
            }
            else
            {
                return View();
            }
        }

    }
}