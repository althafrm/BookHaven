using BookHaven.Models;
using BookHaven.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public List<Order> ListOrdersPaginated(int pageNumber, int pageSize, out int totalRecords)
        {
            return _repository.ListOrdersPaginated(pageNumber, pageSize, out totalRecords);
        }

        public Order GetOrderById(Guid orderId)
        {
            return _repository.GetOrderById(orderId);
        }

        public void AddOrder(Order order)
        {
            _repository.AddOrder(order);
        }

        public void UpdateOrder(Order order)
        {
            _repository.UpdateOrder(order);
        }

        public void DeleteOrder(Guid orderId)
        {
            _repository.DeleteOrder(orderId);
        }
    }
}
