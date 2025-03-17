using BookHaven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Repositories
{
    public interface IOrderRepository
    {
        List<Order> ListOrdersPaginated(int pageNumber, int pageSize, out int totalRecords);
        Order GetOrderById(Guid orderId);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Guid orderId);
    }
}
