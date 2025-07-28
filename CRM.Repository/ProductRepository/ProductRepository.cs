using CRM.Repository.Helpers;
using CRM.Repository.ProductRepository;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Repository.ProductRepository
{
    public class ProductRepository : BasePlugin, IProductRepository
    {
        public ProductRepository()
        {
            _Service = OrganizationServiceFactory.GetCrmService();
        }
        public Entity CreateProductAsync(Entity product)
        {
            _Service.Create(product);
            return product;
        }

        public DataCollection<Entity> GetAllProductsAsync()
        {
            string fetchXml = @"
                <fetch>
                <entity name='initiumc_product_ss'>
                <attribute name='initiumc_productname' />
                <attribute name='initiumc_currentstock' />
                </entity>
                </fetch>";

            return XrmExtensions.FetchMultiple(_Service, fetchXml);
        }

        public Entity GetProductByIdAsync(Guid id)
        {
            string fetchXml = $@"
                <fetch>
                <entity name='initiumc_product_ss'>
                <attribute name='initiumc_productname' />
                <attribute name='initiumc_currentstock' />
                <filter>
                <condition attribute='initiumc_product_ssid' operator='eq' value='{id}' />
                </filter>
                </entity>
                </fetch>";

            return XrmExtensions.Fetch(_Service, fetchXml);
        }
    }
}
