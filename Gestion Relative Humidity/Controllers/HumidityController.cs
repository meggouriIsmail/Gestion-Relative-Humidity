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
        private readonly IUnitOfWork<User> _user;
        private readonly IUnitOfWork<Station> _station;
        private readonly IUnitOfWork<Observateur> _observateur;

        public HumidityController(IUnitOfWork<User> user, IUnitOfWork<Station> station, IUnitOfWork<Observateur> observateur)
        {
            _user = user;
            _station = station;
            _observateur = observateur;
        }

        [Authorize(AuthenticationSchemes = Startup.CookieScheme)]
        public IActionResult Index()
        {
            var model = new HumidityModel
            {
                Observateurs = FillSelectListObservateurs(),
                Stations = FillSelectList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(HumidityModel model)
        {
            if (ModelState.IsValid)
            {
                var md = model;

                return Redirect("/home/index");
            } 
            else
            {
                var models = new HumidityModel
                {
                    Observateurs = FillSelectListObservateurs(),
                    Stations = FillSelectList()
                };
                return View(models);
            }
        }

        public IActionResult Station()
        {
            return View(_station.Entity.GetAll());
        }

        Station FillSelectList()
        {
            var stations = _station.Entity.GetById(2);
            return stations;
        }

        List<Observateur> FillSelectListObservateurs()
        {
            var observateurs = _observateur.Entity.GetAll();
            List<Observateur> obsevs = observateurs.Where(obs => obs.StationId == 2).ToList();
            return obsevs;
        }
    }
}
