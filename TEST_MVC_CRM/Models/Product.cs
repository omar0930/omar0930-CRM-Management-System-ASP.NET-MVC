using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEST_MVC_CRM.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int CurrentStock { get; set; }
    }
}