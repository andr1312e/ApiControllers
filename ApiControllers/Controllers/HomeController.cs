using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiControllers.Models;

namespace ApiControllers.Controllers
{
    public class HomeController : Controller
    {
        public IRepository repository { set; get; }
        // GET: Home
        public HomeController(IRepository repo) 
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View(repository.Reservations);
        }
        [HttpPost]
        public IActionResult AddReservation(Reservation reservation)
        {
            repository.AddReservation(reservation);
            return RedirectToAction("Index");
        }
    }
}