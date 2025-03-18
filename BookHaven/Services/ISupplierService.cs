using BookHaven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Services
{
    public interface ISupplierService
    {
        List<Supplier> GetSuppliers();
        List<Supplier> GetSuppliersPaginated(int pageNumber, int pageSize, string searchQuery, out int totalRecords);
        Supplier GetSupplierById(Guid id);
        void AddSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(Guid id);
    }
}
