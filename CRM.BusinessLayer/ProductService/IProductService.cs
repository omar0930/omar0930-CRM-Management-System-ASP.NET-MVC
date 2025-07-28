using CRM.BusinessLayer.Dtos;
using CRM.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.Product
{
    public interface IProductService
    {
        //read only list
        List<ProductModel> GetAllProductsAsync();
        ProductModelDto GetProductByIdAsync(Guid id);
        ProductModel CreateProductAsync(ProductModel product);
    }
}
