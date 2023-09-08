using System.ComponentModel.DataAnnotations;

namespace FinalWebsite.WebUI.View_Models
{
    public class RegisterVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string UserName { get; set; } = null!;
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }= null!;
        [DataType(DataType.Password)]
        public string Password { get; set; }=null!;
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ComfirmPassword { get; set; }=null !;
    }
}
