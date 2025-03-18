using BookHaven.Models;
using BookHaven.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Services
{
    public class SupplierOrderService : ISupplierOrderService
    {
        private readonly ISupplierOrderRepository _repository;

        public SupplierOrderService(ISupplierOrderRepository repository)
        {
            _repository = repository;
        }

        public List<SupplierOrder> ListSupplierOrdersPaginated(int pageNumber, int pageSize, out int totalRecords)
        {
            return _repository.ListSupplierOrdersPaginated(pageNumber, pageSize, out totalRecords);
        }

        public SupplierOrder GetSupplierOrderById(Guid supplierOrderId)
        {
            return _repository.GetSupplierOrderById(supplierOrderId);
        }

        public void AddSupplierOrder(SupplierOrder supplierOrder)
        {
            _repository.AddSupplierOrder(supplierOrder);
        }

        public void UpdateSupplierOrder(SupplierOrder supplierOrder)
        {
            _repository.UpdateSupplierOrder(supplierOrder);
        }

        public void DeleteSupplierOrder(Guid supplierOrderId)
        {
            _repository.DeleteSupplierOrder(supplierOrderId);
        }
    }
}
