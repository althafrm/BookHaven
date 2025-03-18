using BookHaven.Models;
using BookHaven.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repository;

        public SupplierService(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public List<Supplier> GetSuppliers() => _repository.GetAllSuppliers();

        public List<Supplier> GetSuppliersPaginated(int pageNumber, int pageSize, string searchQuery, out int totalRecords)
        {
            return _repository.GetSuppliersPaginated(pageNumber, pageSize, searchQuery, out totalRecords);
        }

        public Supplier GetSupplierById(Guid id) => _repository.GetSupplierById(id);
        public void AddSupplier(Supplier supplier) => _repository.AddSupplier(supplier);
        public void UpdateSupplier(Supplier supplier) => _repository.UpdateSupplier(supplier);
        public void DeleteSupplier(Guid id) => _repository.DeleteSupplier(id);
    }
}
