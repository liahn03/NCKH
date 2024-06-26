using DocumentSharing.Models;
using Microsoft.AspNetCore.Mvc;

namespace DocumentSharing.Controllers {
    public class TagController : Controller {
        private readonly DocumentSharingContext _context;

        public TagController(DocumentSharingContext context) {
            _context = context;
        }

        public IActionResult Index() {
            return View();
        }
    }
}
