using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Repository
{
    public interface IProductRepository
    {
        DataCollection<Entity> GetAllProductsAsync();
        Entity GetProductByIdAsync(Guid id);
        Entity CreateProductAsync(Entity product);
    }
}
