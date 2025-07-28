using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Repository.Models
{
    public class StockMovement
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public ProductModel Product { get; set; }
        public int Quantity { get; set; }
        public DateTime? Date { get; set; }
        public int MovementType { get; set; }
    }
}
