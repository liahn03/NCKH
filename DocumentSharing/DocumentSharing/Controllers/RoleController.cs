using DocumentSharing.Models;
using Microsoft.AspNetCore.Mvc;

namespace DocumentSharing.Controllers {
    public class RoleController : Controller {
        private readonly DocumentSharingContext _context;

        public RoleController(DocumentSharingContext context) {
            _context = context;
        }

        public IActionResult Index() {
            return View();
        }
    }
}
