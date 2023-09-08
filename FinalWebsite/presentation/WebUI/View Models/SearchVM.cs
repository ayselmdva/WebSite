using FinalWebsite.Data.Entities;

namespace FinalWebsite.WebUI.View_Models
{
    public class SearchVM
    {
        public List<Movie> Movies { get; set; }
        public List<Genre>? Genres { get; set; }
        public string? MovieName { get; set; }
        public int? GenreId { get; set; }
        public Movie? Movie { get; set; }
    }
}
