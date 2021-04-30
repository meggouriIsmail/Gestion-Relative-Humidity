using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Gestion_Relative_Humidity.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Relative_Humidity.Controllers
{
    [Authorize(AuthenticationSchemes = Startup.CookieScheme)]
    public class HumidityController : Controller
    {
        private readonly IHostingEnvironment _hosting;
        private readonly IUnitOfWork<User> _user;
        private readonly IUnitOfWork<Station> _station;

        public HumidityController(IHostingEnvironment hosting, IUnitOfWork<User> user, IUnitOfWork<Station> station)
        {
            _hosting = hosting;
            _user = user;
            _station = station;
        }

        [Authorize(AuthenticationSchemes = Startup.CookieScheme)]
        public IActionResult Index()
        {
            var model = new HumidityModel
            {
                Stations = FillSelectList()
            };

            return View(model);
        }
        public IActionResult Station()
        {
            return View(_station.Entity.GetAll());
        }

        List<Station> FillSelectList()
        {
            var stations = _station.Entity.GetAll().ToList();
            stations.Insert(0, new Station { StationId = -1, NomStation = "--- Please select an author ---" });
            return stations;
        }
    }
}
