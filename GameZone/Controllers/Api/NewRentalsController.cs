using GameZone.DTOs;
using GameZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameZone.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDTO newRental)
        {
            if (newRental.GameIds.Count == 0)
                return BadRequest("No Game Ids has been given");
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("CustomerId is not valid");

            var games = _context.Games.Where(g => newRental.GameIds.Contains(g.Id)).ToList();

            if (games.Count != newRental.GameIds.Count)
                return BadRequest("One or more GameIds are invalid.");

            foreach(var game in games)
            {
                if (game.NumberAvailable == 0)
                    return BadRequest("Game is not available.");

                game.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Game = game,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
