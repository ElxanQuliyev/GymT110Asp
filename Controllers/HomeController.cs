using GymT110Asp.Data;
using GymT110Asp.Models;
using GymT110Asp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GymT110Asp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM vm = new HomeVM()
            {
                Sliders=_context.Sliders.ToList(),
                Products=_context.Products.ToList(),
                Blogs=_context.Blogs.ToList()
            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public List<Blog> FindBlogById(int? categoryId,int? blogId)
        {
            return _context.Blogs.Where(x => x.Id != blogId && x.BlogCategoryId == categoryId).ToList();
        }

        public IActionResult FeaturedDetail(int? id)
        {
            if (id == null) return NotFound();

            var findBlog = _context.Blogs.FirstOrDefault(x => x.Id == id);

            if (findBlog == null) return NotFound();

            BlogVM blogVm = new()
            {
                BlogSingle = findBlog,
                SameBlogs=FindBlogById(findBlog.BlogCategoryId,id)
            };
            return View(blogVm);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
