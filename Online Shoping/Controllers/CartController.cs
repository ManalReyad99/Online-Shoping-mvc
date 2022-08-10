using Microsoft.AspNetCore.Mvc;
using Online_Shoping.Models;
using Online_Shoping.Reporistry;

using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Online_Shoping.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository cartRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IOrderRepositry orderreposatory;

        public CartController(ICartRepository cartRepository, UserManager<ApplicationUser> userManager,IOrderRepositry orderRepositry)
        {
            this.cartRepository = cartRepository;
            this.userManager = userManager;
            orderreposatory = orderRepositry;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);
        public async Task<IActionResult> Add(int pid)
        {
            var userid = await GetCurrentUserAsync();
            Cart cart = new Cart();
            cart.product_id = pid;

            cart.user_id = Convert.ToString(userid);
            int effetrow = cartRepository.insert(cart);
            if(effetrow>=1)
            {
                return RedirectToAction("showcart");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
        }
       
        public async Task<IActionResult> showcart()
        {
            var userid = await GetCurrentUserAsync();
            List<Cart> carts = cartRepository.getcartbyuserid(userid.ToString());
            foreach(var item in carts)
            {
                ViewData["products"] = item;
            }
            ViewData["TotalPrice"] = cartRepository.CalcTotalPrice(userid.Id);
            return View();
        }

        public IActionResult Delete(int Userid)
        {
            int rows=cartRepository.delete(Userid);
            if(rows>=1)
            {
                return RedirectToAction("showcart");
            }
            else
            {
                ViewData["error"] = "can not delete";
            }
            return RedirectToAction("showcart");
        }

        public IActionResult createorder()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> createorder(Order order)
        {
            //o.insert(order);
            var userid = await GetCurrentUserAsync();
            List<Cart> carts = cartRepository.getcartbyuserid(userid.ToString());
            OrderDetails orderDetails= new OrderDetails();
            foreach(var item in carts)
            {
                orderDetails.product_id = item.product_id;
                orderDetails.order_id = order.Id;
                orderDetails.quantity = item.quentity;
                //od.insert(orderDetails);
                orderreposatory.insertOrderDetails(orderDetails);
            }
            return RedirectToAction("Delete", new { Userid = Convert.ToInt32(userid) });
        }

    }
}
