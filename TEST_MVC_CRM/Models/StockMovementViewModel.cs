using CRM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEST_MVC_CRM.Models
{
    public class StockMovementViewModel
    {
        public Guid Id { get; set; }
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime? Date { get; set; }
        public int MovementType { get; set; }
    }
}