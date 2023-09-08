using FinalWebsite.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace FinalWebsite.Business.DTO_s.ActorDto_s
{
    public class ActorPostDto
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Image { get; set; } = null!;
        public IFormFile? ImageFile { get; set; }
    }
}
