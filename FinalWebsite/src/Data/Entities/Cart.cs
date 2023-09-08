using FinalWebsite.Data.Entities.Common;

namespace FinalWebsite.Data.Entities
{
    public class Cart:BaseEntity
    {
        public string FullName { get; set; } = null!;
        public string KartNum { get; set; } = null!;
        public DateTime ExprationDate { get; set; }
        public int CVV { get; set; }

    }
}
