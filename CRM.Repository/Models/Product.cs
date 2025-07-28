using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Repository
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int CurrentStock { get; set; }
    }
}