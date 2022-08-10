using System.ComponentModel.DataAnnotations;

namespace Online_Shoping.ViewModels
{
    public class AccountLoginViewModel
    {
     
        [Required]
        public string username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public bool isPresist { get; set; }
    }
}
