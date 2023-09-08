using FinalWebsite.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalWebsite.WebUI.View_Models
{
    public class CrewVM 
    { 
        public List<Director>?Directors { get; set; }
        public List<Actor>?Actors { get; set; }
		public List<Movie>? Movies { get; set; }
		public string FullName { get; set; } = null!;
		public string? About { get; set; }
		public string? Image { get; set; }
		public IFormFile? ImageFile { get; set; }
	}
}
