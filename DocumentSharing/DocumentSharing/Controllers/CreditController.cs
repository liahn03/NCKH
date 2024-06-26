using DocumentSharing.Models;
using Microsoft.AspNetCore.Mvc;

namespace DocumentSharing.Controllers {
    public class CreditController : Controller {
        private readonly DocumentSharingContext _context;

        public CreditController(DocumentSharingContext context) {
            _context = context;
        }

        public IActionResult Index() {
            return View();
        }
    }
}
