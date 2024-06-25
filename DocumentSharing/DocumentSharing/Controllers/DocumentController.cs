using Microsoft.AspNetCore.Mvc;

namespace DocumentSharing.Controllers
{
    public class DocumentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
