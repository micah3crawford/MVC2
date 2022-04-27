using MVC2.Models;
using MVC2.Models.Entities;

namespace MVC2.Services
{
    public interface IPlayerRepository
    {
        ICollection<Player> ReadAll();
        Player Create(Player newPlayer);
        Player? Read(int id);

        Reports CreateReport(int playerId, Reports report);

        Health CreateHealth(int playerId, Health health);
        void Update(int oldId, Player player);
        
        void Delete(int id);
        
    }
}
