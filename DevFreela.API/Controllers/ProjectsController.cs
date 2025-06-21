using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
