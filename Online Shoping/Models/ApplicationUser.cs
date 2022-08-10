
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Online_Shoping.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }
        public virtual List<Order> orders { get; set; }
        public virtual ICollection<Cart> cart { get; set; }
    }
}
