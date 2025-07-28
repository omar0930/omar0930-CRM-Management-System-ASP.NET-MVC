using CRM.BusinessLayer.Dtos;
using CRM.BusinessLayer.Product;
using CRM.Repository;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductModel CreateProductAsync(ProductModel product)
        {
            try
            {
                Entity productEntity = new Entity("initiumc_product_ss");
                productEntity["initiumc_productname"] = product.ProductName;
                productEntity["initiumc_currentstock"] = product.CurrentStock;
                _productRepository.CreateProductAsync(productEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public List<ProductModel> GetAllProductsAsync()
        {
            List<ProductModel> products = new List<ProductModel>();

            var AllProducts = _productRepository.GetAllProductsAsync();
            foreach (var product in AllProducts)
            {
                products.Add(new ProductModel
                {
                    Id = product.Id,
                    ProductName = product.GetAttributeValue<string>("initiumc_productname"),
                    CurrentStock = product.GetAttributeValue<int>("initiumc_currentstock"),
                });
            }

            return products;
        }

        public ProductModelDto GetProductByIdAsync(Guid id)
        {
            var product = _productRepository.GetProductByIdAsync(id);
            ProductModelDto productModelDto = new ProductModelDto()
            {
                Id = product.Id,
                ProductName = product.GetAttributeValue<string>("initiumc_productname"),
                CurrentStock = product.GetAttributeValue<int>("initiumc_currentstock"),
            };
            return productModelDto;
        }
    }
}
