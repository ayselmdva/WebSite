using System.ComponentModel.DataAnnotations;

namespace FinalWebsite.WebUI.View_Models
{
    public class LoginVM
    {
        public int Id { get; set; }
        public string UserNameOrEmail { get; set; } = null!;
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
