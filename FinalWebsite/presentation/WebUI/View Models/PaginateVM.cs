using FinalWebsite.Data.Entities;

namespace FinalWebsite.WebUI.View_Models
{
    public class PaginateVM<T>
    {
        public List<T>? Items { get; set; }
        public int PageCount { get; set; } 
        public int Take { get; set; }
        public int CurrentPage { get; set; }

    }
}
