using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_Sample.Models;

namespace ASP_Sample.Controllers
{
    public class BooksController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            MvcBookContext context = HttpContext.RequestServices.GetService(typeof(ASP_Sample.Models.MvcBookContext)) as MvcBookContext;

            return View(context.GetAllFilms());
        }


        public IActionResult Details(int id)
        {
            MvcBookContext context =  HttpContext.RequestServices.GetService(typeof(ASP_Sample.Models.MvcBookContext)) as MvcBookContext;

            return View(context.GetBookFromID(id));
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }
    }
}
