using FinalWebsite.Data.Entities.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalWebsite.Data.Entities
{
    public class Actor:BaseEntity
    {
        public string FullName { get; set; } = null!;
        public string? About { get; set; }
        public string? Image { get; set; }
        public List<Movie>? Movies { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
