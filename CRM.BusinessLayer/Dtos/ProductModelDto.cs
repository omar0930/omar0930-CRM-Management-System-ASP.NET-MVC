using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.Dtos
{
    public class ProductModelDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int CurrentStock { get; set; }
    }
}
