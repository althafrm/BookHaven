using BookHaven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Services
{
    public interface ICustomerService
    {
        List<Customer> GetCustomersPaginated(int pageNumber, int pageSize, string searchQuery, out int totalRecords);
        Customer GetCustomerById(Guid id);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Guid id);
    }
}
