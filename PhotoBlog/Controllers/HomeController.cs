using Microsoft.AspNetCore.Mvc;
using PhotoBlog.Data;
using PhotoBlog.Models;
using System.Diagnostics;

namespace PhotoBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index(string tagName)
        {
            
            var posts = _db.Posts.Include(x=>x.Tags).OrderByDescending(x => x.CreatedTime).ToList();
            if (!string.IsNullOrEmpty(tagName))
            {
                posts = posts.Where(p => p.Tags.Any(t => t.Name == tagName)).ToList();
            }
            return View(posts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Search(string tagSearch)
        {
            ViewBag.Search = tagSearch; 
            var posts = _db.Posts.Include(x => x.Tags).OrderByDescending(x => x.CreatedTime).ToList();
            if (!string.IsNullOrEmpty(tagSearch))
            {
                posts = posts.Where(p => p.Tags.Any(t => t.Name == tagSearch)).ToList();
            }
            return View("Index",posts);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}