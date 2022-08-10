using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Identity;
using Online_Shoping.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Shoping.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Online_Shoping.Reporistry
{
    public class OrderRepository : IOrderRepositry
    {
        Context context;
      

        public OrderRepository(Context _context)
        {
            context = _context;
        }

        int SaveChanges()
        {
            int row = context.SaveChanges();
            return row;
        }
        public List<Order> GetAll()
        {
            return context.orders.ToList();
        }

        public Order GetById(int id)
        {
            return context.orders.FirstOrDefault(o => o.Id == id);
        }

        public int insert(Order order)
        {
            context.orders.Add(order);


            return SaveChanges();

        }

        public int update(int id, Order newOrder)
        {
            Order OldOrder = GetById(id);
            if (OldOrder != null)
            {
                OldOrder.Address = newOrder.Address;
                OldOrder.user_id = newOrder.user_id;
                OldOrder.City = newOrder.City;
                OldOrder.PaymentType = newOrder.PaymentType;
                return SaveChanges();
            }
            return 0;
        }
        public int delete(int id)
        {
            context.orders.Remove(GetById(id));

            return SaveChanges();

        }

        public List<Order> showOrdersForOneCustomerAsync(string userID)
        {

            List<Order> userOrder = context.orders.Where(s => s.user_id == userID).ToList();
            return userOrder;

        }
        public List<OrderDetails> showOrderdetailsForOnePerson(int orderId)
        {
            List<OrderDetails> orderDetails = context.orderdetails.Include(p => p.product).Where(Od => Od.order_id == orderId).ToList();
            return orderDetails;
        }
        public List<OrderDetails> showAllOrderDetails()
        {
            List<OrderDetails> orderDetails = context.orderdetails.ToList();
            return orderDetails;
        }
        public List<Order> showOrdersByDate(DateTime date)
        {
            List<Order> order = context.orders.Where(o => o.date == date).ToList();
            return order;
        }
        virtual
      public List<OrderDetails> ShowDetailsInOrderDate(int orderId)
        {
            List<OrderDetails> orderDeails = context.orderdetails.Include(p => p.product).Where(od => od.order_id == orderId).ToList();
            return orderDeails;
        }
        public void insertOrderDetails(OrderDetails orderdetail)
        {

            context.orderdetails.Add(orderdetail);
            context.SaveChanges();
        }
    }
}
