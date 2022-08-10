using Online_Shoping.Models;
using System.Collections.Generic;

namespace Online_Shoping.Reporistry
{
    public interface ICartRepository : IReporistry<Cart>
    {
        public List<Cart> getcartbyuserid(string userid);
        float CalcTotalPrice(string userID);
    }
}
