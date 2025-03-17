using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Models
{
    public class SaleDetail
    {
        public Guid Id { get; set; }
        public Guid SaleId { get; set; }
        public Guid BookId { get; set; }
        public string BookTitle { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
