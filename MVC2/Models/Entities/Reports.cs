using MVC2.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVC2.Models
{
    public class Reports
    {
        [Key]
        public string? PlayerName { get; set; }
        public Sport Sport { get; set; }
        [StringLength(250)]
        public string ScoutReport { get; set; } = String.Empty;
        public Player? Player { get; set; }
        public int Id { get; internal set; }
    }
    //Enum of sports players participate in
    public enum Sport
    {
        Bsketball, Football, Baseball, Soccer
    }

}
