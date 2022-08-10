
using Online_Shoping.Models;
using System;
using System.Collections.Generic;

namespace Online_Shoping.Reporistry
{
    public interface IOrderRepositry : IReporistry<Order>
    {
        Order GetById(int id);
        List<Order> showOrdersForOneCustomerAsync(string userID);
        List<OrderDetails> showAllOrderDetails();
        List<OrderDetails> showOrderdetailsForOnePerson(int orderId);
        List<Order> showOrdersByDate(DateTime date);
        List<OrderDetails> ShowDetailsInOrderDate(int orderId);
        void insertOrderDetails(OrderDetails orderdetail);
    }
}
