using BookHaven.Models;
using BookHaven.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Services
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _repository;

        public SalesService(ISalesRepository repository)
        {
            _repository = repository;
        }

        public List<Sale> ListSalesPaginated(int pageNumber, int pageSize, out int totalRecords)
        {
            return _repository.ListSalesPaginated(pageNumber, pageSize, out totalRecords);
        }

        public Sale GetSaleById(Guid saleId)
        {
            return _repository.GetSaleById(saleId);
        }

        public void AddSale(Sale sale)
        {
            _repository.AddSale(sale);
        }

        public void UpdateSale(Sale sale)
        {
            _repository.UpdateSale(sale);
        }

        public void DeleteSale(Guid saleId)
        {
            _repository.DeleteSale(saleId);
        }
    }
}
