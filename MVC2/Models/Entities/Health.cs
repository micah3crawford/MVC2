using MVC2.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVC2.Models.Entities
{
    public class Health
    {
        [Key]
        public string? PlayerName { get; set; }
        public Status Status { get; set; }
        [StringLength(50)]
        public string HealthRecord { get; set; } = String.Empty;
        public Player? Player { get; set; }
        public int Id { get; internal set; }
       
        
    }


   // Enum of sports players participate in
    public enum Status
    {
        Injured,
        Healthy,
        Recovery
    }
}
