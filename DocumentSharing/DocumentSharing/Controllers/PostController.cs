using DocumentSharing.Models;
using Microsoft.AspNetCore.Mvc;

namespace DocumentSharing.Controllers {
    public class PostController : Controller {
        private readonly DocumentSharingContext _context;

        public PostController(DocumentSharingContext context) {
            _context = context;
        }

        public IActionResult Index() {
            return View();
        }

        public void Create() {
            //test add Post with tags
            _context.Posts.Add(new Post {
                PostId = "p2",
                Tags = _context.Tags.ToList()
            });

            _context.SaveChanges();
        }
    }
}
