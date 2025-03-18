using BookHaven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Repositories
{
    public interface ISupplierOrderRepository
    {
        List<SupplierOrder> ListSupplierOrdersPaginated(int pageNumber, int pageSize, out int totalRecords);
        SupplierOrder GetSupplierOrderById(Guid supplierOrderId);
        void AddSupplierOrder(SupplierOrder supplierOrder);
        void UpdateSupplierOrder(SupplierOrder supplierOrder);
        void DeleteSupplierOrder(Guid supplierOrderId);
    }
}
