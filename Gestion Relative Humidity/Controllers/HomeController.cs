using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Gestion_Relative_Humidity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Gestion_Relative_Humidity.Controllers
{
    [Authorize(AuthenticationSchemes = Startup.CookieScheme)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHostingEnvironment _hosting;
        private readonly IUnitOfWork<User> _user;

        public HomeController(ILogger<HomeController> logger, IHostingEnvironment hosting, IUnitOfWork<User> user)
        {
            _logger = logger;
            _hosting = hosting;
            _user = user;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
