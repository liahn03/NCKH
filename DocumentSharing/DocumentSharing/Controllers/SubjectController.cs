using DocumentSharing.Models;
using Microsoft.AspNetCore.Mvc;

namespace DocumentSharing.Controllers {
    public class SubjectController : Controller {
        private readonly DocumentSharingContext _context;

        public SubjectController(DocumentSharingContext context) {
            _context = context;
        }

        public IActionResult Index() {
            return View();
        }
    }
}
