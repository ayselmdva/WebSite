using FinalWebsite.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalWebsite.WebUI.View_Models
{
    public class MovieVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Year { get; set; }
        public decimal Rate { get; set; }
        public int RunTime { get; set; }
        public string Description { get; set; } = null!;
        public decimal TicketPrice { get; set; }
        public decimal OnlineWathcPrice { get; set; }
        public Director? Director { get; set; }
        public int DirectorId { get; set; }
        public List<Actor>? Actors { get; set; }
        public List<int> ActorIds { get; set; }=null!;
        public Genre? Genre { get; set; }
        public int GenreId { get; set; }
        public string? Video { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        [NotMapped]
        public IFormFile? VideoFile { get; set; }
    }
}
