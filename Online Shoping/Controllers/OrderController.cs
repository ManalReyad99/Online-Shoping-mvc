using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_Shoping.Models;
using Online_Shoping.Reporistry;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Online_Shoping.Controllers
{
    public class OrderController : Controller
    {
        IOrderRepositry orderRepositry;
        private readonly UserManager<ApplicationUser> userManager;
        ICartRepository carto;
        public OrderController(IOrderRepositry _orderRepositry, UserManager<ApplicationUser> userManager, ICartRepository cart)
        {
            orderRepositry = _orderRepositry;
            this.userManager = userManager;
            carto = cart;
        }

        //public IActionResult Index()
        //{
        //    List<Order> OrderList = orderRepositry.GetAll();
        //    return View(OrderList);
        //}
        //Show All Orders
        public IActionResult ShowOrders()
        {
            List<Order> orders = orderRepositry.GetAll();
            return View("ShowOrders", orders);
        }
        public IActionResult CreateNewOrder()
        {
            return View("CreateNewOrder");
        }
        //save
        [HttpPost]
        public async Task<IActionResult> SaveNewOrder(Order newOrder)
        {
            if (ModelState.IsValid == true)
            {
                var user = await GetCurrentUserAsync();
                newOrder.user_id = user.Id;
                newOrder.TotalPrice = carto.CalcTotalPrice(user.Id);
                orderRepositry.insert(newOrder);
                return RedirectToAction("Index");
            }

            return View("CreateNewOrder", newOrder);

        }

        //public IActionResult Edit(int id)
        //{
        //    Order Order = orderRepositry.GetById(id);
        //    return View("Edit", Order);

        //}

        [HttpPost]
        //public IActionResult SaveEdit(int id, Order NewOrder)
        //{
        //    if (ModelState.IsValid == true)
        //    {
        //        //save
        //        orderRepositry.update(id, NewOrder);
        //        return RedirectToAction("Index");
        //    }
        //    //not saved

        //    return View("Edit", NewOrder);
        //}
        public IActionResult RemoveOrder(int id)
        {
            if (ModelState.IsValid)
            {
                orderRepositry.delete(id);
                return RedirectToAction("ShowOrders");



            }
            return RedirectToAction("ShowOrders");
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);
        public async Task<IActionResult> ShowOrdersForUser()
        {
            var user = await GetCurrentUserAsync();
            List<Order> orders = orderRepositry.showOrdersForOneCustomerAsync(user.Id);
            return View(orders);
        }
        public IActionResult showDetailsForUser(int orderId)
        {
            List<OrderDetails> orderDetails = orderRepositry.showOrderdetailsForOnePerson(orderId);
            Order order = orderRepositry.GetById(orderId);
            ViewData["Order"] = order;
            return View("ShowDetails", orderDetails);
        }
        public IActionResult ShowDetailsForAdmin(int orderId)
        {
            List<OrderDetails> orderDetails = orderRepositry.showAllOrderDetails();
            Order order = orderRepositry.GetById(orderId);
            ViewData["Order"] = order;
            return View("ShowDetails", orderDetails);
        }
        public IActionResult ShowOrderByDate(DateTime date)
        {
            List<Order> orders = orderRepositry.showOrdersByDate(date);
            return View( orders);
        }
        public IActionResult ShowDetailsByDate(int orderId)
        {
            List<OrderDetails> orderDetails = orderRepositry.showAllOrderDetails();
            Order order = orderRepositry.GetById(orderId);
            ViewData["Order"] = order;
            return View("ShowDetails", orderDetails);
        }

    }
}
