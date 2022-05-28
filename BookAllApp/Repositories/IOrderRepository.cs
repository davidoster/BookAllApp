using BookAllApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAllApp.Repositories
{
    public interface IOrderRepository
    {
        Order GetOrderById(string orderId);
        Order Create(Order order);
        Order Update(Order order);
        Order Delete(string ID);
        IEnumerable<Order> AllOrders { get; }
        IEnumerable<Order> MostFrequentOrders { get; }
    }
}
