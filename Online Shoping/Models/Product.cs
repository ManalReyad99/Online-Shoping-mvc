using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Online_Shoping.Models
{
    public class Product
    {
        public int id { get; set; }
        [Required(ErrorMessage = "ProductName REquired")]
        [MaxLength(50)]
        [MinLength(5)]
        public string name { get; set; }
        [Required(ErrorMessage = "ProductPrice REquired")]
        public float price { get; set; }
        public string image { get; set; }
       
        [Required(ErrorMessage = "ProductPrice REquired")]
       
        public int quantity { get; set; }
        public string description { get; set; }

        public string type { get; set; }
        [ForeignKey("category")]
        public int category_id { get; set; }
        public virtual Category category { get; set; }

        public virtual ICollection<Cart> cart { get; set; }
        public virtual ICollection<OrderDetails> orderdetails { get; set; }
    }
}
