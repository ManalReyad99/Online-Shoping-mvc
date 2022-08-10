using Online_Shoping.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Shoping.Models
{
    public class Cart
    {

        public int Id { get; set; }
        [ForeignKey("product")]
        public int product_id { get; set; }
        [ForeignKey("appuser")]
        public string user_id { get; set; }
        public virtual Product product { get; set; }    
        public virtual ApplicationUser appuser { get; set; }
        public int quentity { get; set; }
        public bool status { get; set; }
    }
}
