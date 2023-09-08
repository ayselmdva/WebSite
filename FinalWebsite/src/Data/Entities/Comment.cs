using FinalWebsite.Data.Entities.Common;

namespace FinalWebsite.Data.Entities
{
    public class Comment : BaseEntity
    {
        public string Description { get; set; } = null!;
        public DateTime? Date { get; set; }
        public AppUser? AppUser { get; set; }
        public string AppUserId { get; set; }
        public Movie? Movie { get; set; }
        public int MovieId { get; set; }
        public bool IsDeleted { get; set; }= false;
    }
}
