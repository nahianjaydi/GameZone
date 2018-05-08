using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameZone.Models;
using GameZone.ViewModels;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        // GET: Games
        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageGames)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new GameFormViewModel
            {
                Genres = genres
            };
            return View("GameForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageGames)]
        public ActionResult Save(Game game)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new GameFormViewModel(game)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("GameForm", viewModel);
            }

            if (game.Id == 0)
                _context.Games.Add(game);
            else
            {
                var gameInDb = _context.Games.Single(c => c.Id == game.Id);
                gameInDb.Name = game.Name;
                gameInDb.GenreId = game.GenreId;
                gameInDb.Price = game.Price;
                gameInDb.Rent = game.Rent;
                gameInDb.ReleaseDate = game.ReleaseDate;
                gameInDb.NumberInStock = game.NumberInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Games");
        }

        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageGames))
                return View("List");

            return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var game = _context.Games.Include(g => g.Genre).SingleOrDefault(g => g.Id == id);
            if (game == null)
                return HttpNotFound();
            return View(game);
        }

        [Authorize(Roles = RoleName.CanManageGames)]
        public ActionResult Edit(int id)
        {
            var game = _context.Games.SingleOrDefault(g => g.Id == id);
            if (game == null)
                return HttpNotFound();

            var viewModel = new GameFormViewModel(game)
            {
                Genres = _context.Genres.ToList()
            };
            return View("GameForm", viewModel);
        }
    }
}