using MVC2.Models;
using MVC2.Models.Entities;


namespace MVC2.Services
{
    public class DbPlayerRepository : IPlayerRepository
    {
        private ApplicationDbContext _db;
        public DbPlayerRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        //Create
        public Player Create(Player newPlayer)
        {
            _db.Players.Add(newPlayer);
            _db.SaveChanges();
            return newPlayer;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="report"></param>
        /// <returns></returns>
        public Reports CreateReport(int playerId, Reports report)
        {
            var person = Read(playerId);
            if (person != null)
            {
                person.Report.Add(report);
                Player? player = null;
                report.Player = player;
                _db.SaveChanges();
            }
            return report;

        }

        //Delete
        public void Delete(int id)
        {
            Player? playerToDelete = Read(id);
            if(playerToDelete != null)
            {
                _db.Players.Remove(playerToDelete);
                _db.SaveChanges();
            }
        }

        //Update
        public void Update(int oldId, Player player)
        {
            Player? playerToUpdate = Read(oldId);
            if(playerToUpdate != null)
            {
                playerToUpdate.FirstName = player.FirstName;

                playerToUpdate.LastName = player.LastName;
                //playerToUpdate.TeamName = player.TeamName;
                _db.SaveChanges();
            }
        }

        //Read
        public Player? Read(int id)
        {
            return _db.Players.Find(id);
        }
        //Collection of Players
        public ICollection<Player> ReadAll()
        {
            return _db.Players.ToList();
        }


        //enum Report
        public Reports Report(int playerId, Reports report)
        {
            var player = Read(playerId);
            if (player != null)
            {
                player.Report.Add(report);
                report.Player = player;
                _db.SaveChanges();
            }
            return report;
        }
        //Report Reader
        public Player? ReadReport(int id)
        {
            var player = _db.Players.Find(id);
            if (player != null)
            {
                _db.Entry(player)
                  .Collection(p => p.Report)
                  .Load();
            }

            return player;
        }

        /// <summary>
        /// Create Health
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="health"></param>
        /// <returns></returns>
        public Health CreateHealth(int playerId, Health health)
        {
            var person = Read(playerId);
            if (person != null)
            {
                person.Health.Add(health);
                Player? player = null;
                health.Player = player;
                _db.SaveChanges();
            }
            return health;

        }

        //enum Health
        public Health Health(int playerId, Health health)
        {
            var player = Read(playerId);
            if (player != null)
            {
                player.Health.Add(health);
                health.Player = player;
                _db.SaveChanges();
            }
            return health;
        }
        //Health Reader
        public Player? ReadHealth(int id)
        {
            var player = _db.Players.Find(id);
            if (player != null)
            {
                _db.Entry(player)
                  .Collection(p => p.Report)
                  .Load();
            }

            return player;
        }
    }
}
