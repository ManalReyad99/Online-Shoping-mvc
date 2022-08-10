using System.ComponentModel.DataAnnotations;

namespace Online_Shoping.ViewModels
{
    public class AccountRegisterViewModel
    {
      
        [Required]
        public string username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage ="password not matched")]
        public string confirmPassword { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
