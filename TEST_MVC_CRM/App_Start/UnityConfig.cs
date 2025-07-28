using CRM.BusinessLayer.Product;
using CRM.Repository;
using CRM.Repository.Helpers;
using CRM.Repository.ProductRepository;
using Microsoft.Xrm.Sdk;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Lifetime;
using CRM.BusinessLayer.ProductService;
using CRM.BusinessLayer.StockMovementService;
using CRM.Repository.StockMovementService;

namespace TEST_MVC_CRM
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Register services
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IStockMovementService, StockMovementService>();
            container.RegisterType<IStockMovementRepository, StockMovementRepository>();

            // Set the dependency resolver for MVC
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
