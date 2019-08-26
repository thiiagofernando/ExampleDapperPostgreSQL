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

        public IActionResult RemovePerson(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index", "Person");
        }

        public IActionResult UpdatePerson(int id)
        {
            Person person = repo.GetById(id);

            return View(person);
        }
        [HttpPost]
        public IActionResult UpdatePerson(Person person)
        {
            repo.Update(person);
            return RedirectToAction("Index", "Person");
        }

    }
}