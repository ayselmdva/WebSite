using FinalWebsite.Data.Entities;

namespace FinalWebsite.WebUI.View_Models
{
    public class HomeVM
    {
        public List<Movie>? Movies { get; set; }
        public List<Actor>? Actors { get; set; }
        public List<Director>? Directors { get; set; }
        public Movie? Movie { get; set; }
        public Genre? Genre { get; set; }
        public int GenreId { get; set; }
        public  List<Genre>? Genres { get; set; }
		public string FullName { get; set; } = null!;
		public string? About { get; set; }
		public string? Image { get; set; }
        public string? Video { get; set; }
		public IFormFile? ImageFile { get; set; }
		public IFormFile? VideoFile { get; set; }
	}
}
