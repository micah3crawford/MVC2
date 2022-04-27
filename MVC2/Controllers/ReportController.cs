using Microsoft.AspNetCore.Mvc;
using MVC2.Models;
using MVC2.Services;

namespace MVC2.Controllers
{
    
    public class ReportController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        private readonly IPlayerRepository _playerrepo;

        public ReportController(IPlayerRepository playerrepo)
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
        public IActionResult Create(int playerId, Reports report)
        {
            if (ModelState.IsValid)
            {
                _playerrepo.CreateReport(playerId, report);
                return RedirectToAction("Index", "Player");
            }
            ViewData["Player"] = _playerrepo.Read(playerId);
            return View(report);
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
