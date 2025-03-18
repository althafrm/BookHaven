using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Models
{
    public class SupplierOrder
    {
        public Guid Id { get; set; }
        public Guid SupplierId { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public List<SupplierOrderDetail> SupplierOrderDetails { get; set; } = new List<SupplierOrderDetail>();
    }
}
