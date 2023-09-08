using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalWebsite.Data.Entities
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; } = null!;
        /* public List<Comment>? Comments { get; set; }*/
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }


    }
}
