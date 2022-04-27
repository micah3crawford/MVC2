using Microsoft.AspNetCore.Mvc;
using MVC2.Models;
using MVC2.Models.Entities;
using MVC2.Services;

namespace MVC2.Controllers
{
    //player controller in which will display data about players from the database 
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerrepo;

        public PlayerController(IPlayerRepository playerRepo)
        {
            _playerrepo = playerRepo;
        }
        public IActionResult Index()
        {
            var model = _playerrepo.ReadAll();
            return View(model);
        }

        /// <summary>
        /// Edits player information
        /// </summary>
        /// <param name="id"></param>
        /// <returns> returns view for player </returns>
        public IActionResult Edit (int id)
        {
            var player = _playerrepo.Read(id);
            if(player == null)
            {
                return RedirectToAction("Index");
            }
            return View(player);
        }
        /// <summary>
        /// Edit Post Rewquest
        /// </summary>
        /// <param name="player"></param>
        /// <returns> returns the view for player </returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(Player player)
        {
            if(ModelState.IsValid)
            {
                _playerrepo.Update(player.Id, player);
                return RedirectToAction("Index");
            }
            return View(player);
        }

       /// <summary>
       /// Creates new player
       /// </summary>
       /// <returns> returns the Create view </returns>
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Create post Request
        /// </summary>
        /// <param name="newPlayer"></param>
        /// <returns> returns view for player </returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Player newPlayer)
        {
            if(ModelState.IsValid)
            {
                _playerrepo.Create(newPlayer);
                    return RedirectToAction("Index");
            }
            return View(newPlayer);
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
            return View(player);
        }

        /// <summary>
        /// Deletes Player
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Returns the view for Delete </returns>
        public IActionResult Delete(int id)
        {
            var player = _playerrepo.Read(id);
            if(player == null)
            {
                return RedirectToAction("Index");
            }
            return View(player);
        }
        /// <summary>
        ///  Delete Post Request
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Returns the View for Player's Index </returns>
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _playerrepo.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}
