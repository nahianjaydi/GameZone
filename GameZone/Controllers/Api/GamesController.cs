using GameZone.DTOs;
using GameZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using AutoMapper;

namespace GameZone.Controllers.Api
{
    public class GamesController : ApiController
    {
        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<GameDTO> GetMovies(string query = null)
        {
            var gamesQuery = _context.Games
                .Include(g => g.Genre)
                .Where(g => g.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                gamesQuery = gamesQuery.Where(g => g.Name.Contains(query));

            return gamesQuery
                .ToList()
                .Select(Mapper.Map<Game, GameDTO>);
        }

        public IHttpActionResult GetGame(int id)
        {
            var game = _context.Games.SingleOrDefault(g => g.Id == id);

            if (game == null)
                return NotFound();

            return Ok(Mapper.Map<Game, GameDTO>(game));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageGames)]
        public IHttpActionResult CreateGame(GameDTO gameDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var game = Mapper.Map<GameDTO, Game>(gameDTO);
            _context.Games.Add(game);
            _context.SaveChanges();

            gameDTO.Id = game.Id;
            return Created(new Uri(Request.RequestUri + "/" + game.Id), gameDTO);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageGames)]
        public IHttpActionResult UpdateGame(int id, GameDTO gameDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var gameInDb = _context.Games.SingleOrDefault(g => g.Id == id);

            if (gameInDb == null)
                return NotFound();

            Mapper.Map(gameDTO, gameInDb);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageGames)]
        public IHttpActionResult DeleteGame(int id)
        {
            var gameInDb = _context.Games.SingleOrDefault(g => g.Id == id);

            if (gameInDb == null)
                return NotFound();

            _context.Games.Remove(gameInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
