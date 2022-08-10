using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Shoping.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string PaymentType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [ForeignKey("appuser")]
        public string user_id { get; set; }
        public float TotalPrice { get; set; }
        public DateTime date { get; set; }
        public virtual ApplicationUser appuser {get;set;}
        public virtual ICollection<OrderDetails> orderdetails { get; set; }
    }
}
