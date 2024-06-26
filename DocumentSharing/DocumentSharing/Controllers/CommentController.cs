using DocumentSharing.Models;
using Microsoft.AspNetCore.Mvc;

namespace DocumentSharing.Controllers {
    public class CommentController : Controller {
        private readonly DocumentSharingContext _context;

        public CommentController(DocumentSharingContext context) {
            _context = context;
        }

        public IActionResult Index() {
            return View();
        }
    }
}
