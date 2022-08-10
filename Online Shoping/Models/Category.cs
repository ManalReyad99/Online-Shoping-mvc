using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_Shoping.Models
{
    public class Category
    {
        public int id { get; set; }
        [Required(ErrorMessage = "CategoryName REquired")]
        [MaxLength(20)]
        [MinLength(5)]
        public string name { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
