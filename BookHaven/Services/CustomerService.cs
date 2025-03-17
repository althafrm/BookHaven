using BookHaven.Models;
using BookHaven.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public List<Customer> GetCustomers() => _repository.GetAllCustomers();

        public List<Customer> GetCustomersPaginated(int pageNumber, int pageSize, string searchQuery, out int totalRecords)
        {
            return _repository.GetCustomersPaginated(pageNumber, pageSize, searchQuery, out totalRecords);
        }
        public Customer GetCustomerById(Guid id) => _repository.GetCustomerById(id);
        public void AddCustomer(Customer customer) => _repository.AddCustomer(customer);
        public void UpdateCustomer(Customer customer) => _repository.UpdateCustomer(customer);
        public void DeleteCustomer(Guid id) => _repository.DeleteCustomer(id);
    }
}
