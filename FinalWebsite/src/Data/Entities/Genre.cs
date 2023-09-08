using FinalWebsite.Data.Entities.Common;

namespace FinalWebsite.Data.Entities
{
    public class Genre:BaseEntity
    {
        public string Name { get; set; } = null!;
        public List<Movie>? Movies { get; set; }

    }
}
