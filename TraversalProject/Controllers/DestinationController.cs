﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

        public IActionResult Index()
        {
            var values = destinationManager.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult DestinationDetails(int id)
        {
            ViewBag.i = id;
            var values = destinationManager.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult DestinationDetails(Destination destination)
        {
            return View();
        }
    }
}