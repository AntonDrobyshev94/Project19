using Microsoft.AspNetCore.Mvc;

namespace Project19.Controllers
{
    public class MyDefaultController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.GetDataFromListObject(Repository.db));
        }

        public IActionResult Details(int id)
        {
            return View(Repository.GetConcreteContact(id));
        }
    }
}
