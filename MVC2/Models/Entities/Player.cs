using System.ComponentModel.DataAnnotations;
namespace MVC2.Models.Entities
{
    //player class that takes in player information and runs a collection of reports
    public class Player
    {

        public int Id { get; set; }
        [StringLength(256)]
        public string FirstName { get; set; } = String.Empty;

        [Required]
        public string LastName { get; set; } = String.Empty;
        public string? TeamName { get; set; }
        public string? JerseyNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }

        public ICollection<Reports> Report { get; set; }
        = new List<Reports>();
        public ICollection<Health> Health { get; set; }
       = new List<Health>();


    }
}
