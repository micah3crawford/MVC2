using Microsoft.AspNetCore.Mvc;
using MVC2.Models;
using MVC2.Models.Entities;
using MVC2.Services;
namespace MVC2.Models.Entities
{
    public class HealthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IPlayerRepository _playerrepo;

        public HealthController(IPlayerRepository playerrepo)
        {
            _playerrepo = playerrepo;
        }

        public IActionResult Create([Bind(Prefix = "id")] int playerId)
        {
            var player = _playerrepo.Read(playerId);
            if (player == null)
            {
                return RedirectToAction("Index", "Player");
            }
            ViewData["Player"] = player;
            return View();
        }
        //Create Post for scoutreport
        [HttpPost]
        public IActionResult Create(int playerId, Health health)
        {
            if (ModelState.IsValid)
            {
                _playerrepo.CreateHealth(playerId, health);
                return RedirectToAction("Index", "Player");
            }
            ViewData["Player"] = _playerrepo.Read(playerId);
            return View(health);
        }

        /// <summary>
        /// Details of player
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Returns view for Details</returns>
        public IActionResult Details(int id)
        {
            var player = _playerrepo.Read(id);
            if (player == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
