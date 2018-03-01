using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreWebAppSimple.Models;
using Microsoft.Extensions.FileProviders;

namespace CoreWebAppSimple.Controllers
{   

    public class HomeController : Controller
    {
        private readonly IFileProvider _fileProvider;
        public HomeController(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var contents = _fileProvider.GetDirectoryContents("");
            ViewData["Message"] = "Container Details";

            return View(contents);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
