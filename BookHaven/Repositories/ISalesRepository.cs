using BookHaven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Repositories
{
    public interface ISalesRepository
    {
        List<Sale> ListSalesPaginated(int pageNumber, int pageSize, out int totalRecords);
        Sale GetSaleById(Guid saleId);
        void AddSale(Sale sale);
        void UpdateSale(Sale sale);
        void DeleteSale(Guid saleId);
    }
}
