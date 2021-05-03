﻿using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Interfaces;
using Gestion_Relative_Humidity.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsychroLib;

namespace Gestion_Relative_Humidity.Controllers
{
    [Authorize(AuthenticationSchemes = Startup.CookieScheme)]
    public class HumidityController : Controller
    {
        private readonly IUnitOfWork<Station> _station;
        private readonly IUnitOfWork<Observateur> _observateur;
        private readonly IUnitOfWork<RelativeHumidity> _humidity;

        public HumidityController(IUnitOfWork<User> user,
            IUnitOfWork<Station> station,
            IUnitOfWork<Observateur> observateur,
            IUnitOfWork<RelativeHumidity> humidity)
        {
            _station = station;
            _observateur = observateur;
            _humidity = humidity;
        }

        [Authorize(AuthenticationSchemes = Startup.CookieScheme)]
        public IActionResult Index()
        {
            var model = new HumidityModel
            {
                Stations = FillSelectList(),
                Observateurs = FillSelectListObservateurs()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(HumidityModel model)
        {
            if (ModelState.IsValid)
            {
                var psySI = new Psychrometrics(UnitSystem.SI);
                RelativeHumidity humidity = new RelativeHumidity
                {
                    DateObservation = model.DateObservation,
                    Heur = model.Heur,
                    Sec = model.Sec,
                    Mou = model.Mou,
                    Hum = (int)(psySI.GetRelHumFromTWetBulb(model.Sec, model.Mou, 101050.024) * 100),
                    ThermometreMA = model.ThermometreMA,
                    ThermometreMax = model.ThermometreMax,
                    ThermometreMoyMaxMin = model.ThermometreMoyMaxMin,
                    ThermometreMin = model.ThermometreMin,
                    ThermometreMI = model.ThermometreMI,
                    ObservateurId = model.ObservateurId,
                    StationId = model.StationId,
                };
                _humidity.Entity.Insert(humidity);
                _humidity.Save();
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
            var stations = _station.Entity.GetAll();
            var userClaims = HttpContext.User.Claims.ToList();
            var email = userClaims[0].Value;
            var station = stations.First(st => st.NomStation == email);
            return station;
        }

        List<Observateur> FillSelectListObservateurs()
        {
            var station = FillSelectList();

            var observateurs = _observateur.Entity.GetAll();
            List<Observateur> obsevs = observateurs.Where(obs => obs.StationId == station.StationId).ToList();
            return obsevs;
        }
    }
}
