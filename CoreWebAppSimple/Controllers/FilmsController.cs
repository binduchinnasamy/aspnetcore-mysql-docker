using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebAppSimple.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebAppSimple.Controllers
{
    public class FilmsController : Controller
    {
        public IActionResult Index()
        {
            SakilaContext context = HttpContext.RequestServices.GetService(typeof(SakilaContext)) as SakilaContext;
            return View(context.GetAllFilms());
        }
    }
}