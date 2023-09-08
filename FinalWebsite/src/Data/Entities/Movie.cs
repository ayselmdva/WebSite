using FinalWebsite.Data.Entities.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalWebsite.Data.Entities
{
    public class Movie:BaseEntity
    {
        public string Name { get; set; } = null!;
        public decimal Rate { get; set; }
        public int RunTime { get; set; }
        public int Year { get; set; }
        public string Description { get; set; } = null!;
        public Director? Director { get; set; }
        public int DirectorId { get; set; }
        public List<Actor>? Actors { get; set;}
/*        public List<Comment>? Comments { get; set; }*/
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
