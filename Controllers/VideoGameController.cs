using Microsoft.AspNetCore.Mvc;
using VideoGameApp.Data;
using VideoGameApp.Models;
using System.Linq;
using System.Collections.Generic; // Add this using directive

namespace VideoGameApp.Controllers
{
    public class VideoGamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VideoGamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var games = _context.VideoGames.ToList(); // Updated to use the correct DbSet property name
            return View(games);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VideoGame game)
        {
            if (ModelState.IsValid)
            {
                _context.VideoGames.Add(game); // Updated to use the correct DbSet property name
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        public IActionResult Edit(int id)
        {
            var game = _context.VideoGames.Find(id); // Updated to use the correct DbSet property name
            if (game == null) return NotFound();
            return View(game);
        }

        [HttpPost]
        public IActionResult Edit(int id, VideoGame game)
        {
            if (id != game.Id) return BadRequest("Game ID mismatch.");
            if (ModelState.IsValid)
            {
                _context.Update(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        public IActionResult Delete(int id)
        {
            var game = _context.VideoGames.Find(id); // Updated to use the correct DbSet property name
            if (game != null)
            {
                _context.VideoGames.Remove(game); // Updated to use the correct DbSet property name
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Popular()
        {
            var popularGames = new List<PopularGame>
            {
                new PopularGame { Title = "Grand Theft Auto V", ImageUrl = "/images/game1.jpg", PurchaseUrl = "https://store.steampowered.com/app/271590/Grand_Theft_Auto_V/" },
                new PopularGame { Title = "Red Dead Redemption 2", ImageUrl = "/images/game2.jpg", PurchaseUrl = "https://store.steampowered.com/app/1174180/Red_Dead_Redemption_2/" },
                new PopularGame { Title = "Don't Starve Together", ImageUrl = "/images/game3.jpg", PurchaseUrl = "https://store.steampowered.com/app/322330/Dont_Starve_Together/" },
                new PopularGame { Title = "Delta Force", ImageUrl = "/images/game4.jpg", PurchaseUrl = "https://store.steampowered.com/app/2507950/Delta_Force/" },
                new PopularGame { Title = "War Thunder", ImageUrl = "/images/game5.jpg", PurchaseUrl = "https://store.steampowered.com/app/236390/War_Thunder/" },
                new PopularGame { Title = "The Sims 4", ImageUrl = "/images/game6.jpg", PurchaseUrl = "https://store.steampowered.com/app/1222670/The_Sims_4/" }
                                   
            };

            return View(popularGames);
        }
    }
}
