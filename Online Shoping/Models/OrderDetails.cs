using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Shoping.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        [ForeignKey("product")]
        
        public int product_id { get; set; }

        [ForeignKey("order")]
      
        public int order_id { get; set; }
        public virtual Product product { get; set; }
        public virtual Order order { get; set; }
      
        public int quantity { get; set; }
    }
}
