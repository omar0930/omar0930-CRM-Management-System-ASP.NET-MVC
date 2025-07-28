using CRM.BusinessLayer.Dtos;
using CRM.Repository;
using CRM.Repository.Models;
using CRM.Repository.StockMovementService;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.StockMovementService
{
    public class StockMovementService : IStockMovementService
    {
        private readonly IStockMovementRepository _stockMovementRepository;
        private readonly IProductRepository _productRepository;


        public StockMovementService(IStockMovementRepository stockMovementRepository, IProductRepository productRepository)
        {
            _stockMovementRepository = stockMovementRepository;
            _productRepository = productRepository;
        }
        public void AddStockMovementAsync(StockMovementDto stockMovement)
        {
            Entity stockMovementEntity = new Entity("initiumc_stockmovement");

            stockMovementEntity["initiumc_movementtype"] = new OptionSetValue(stockMovement.MovementType);
            stockMovementEntity["initiumc_quantity"] = stockMovement.Quantity;
            stockMovementEntity["initiumc_date"] = stockMovement.Date;
            stockMovementEntity["initiumc_relatedproduct"] = new EntityReference("initiumc_product_ss", stockMovement.ProductId);

            _stockMovementRepository.Add(stockMovementEntity);
        }

        public void DeleteStockMovementAsync(StockMovementDto stockMovement)
        {
            throw new NotImplementedException();
        }

        public List<StockMovementDto> GetAllStockMovementsAsync()
        {
            List<StockMovementDto> stockMovements = new List<StockMovementDto>();

            var myStockMovements = _stockMovementRepository.GetAll();

            foreach (var stockMovement in myStockMovements)
            {
                var ProductRef = XrmExtensions.GetEntityReference(stockMovement, "initiumc_relatedproduct");
                var Product = _productRepository.GetProductByIdAsync(ProductRef.Id);

                ProductModel product = new ProductModel
                {
                    Id = Product.Id,
                    ProductName = Product.GetAttributeValue<string>("initiumc_productname"),
                    CurrentStock = Product.GetAttributeValue<int>("initiumc_currentstock"),
                };

                stockMovements.Add(new StockMovementDto
                {
                    Id = stockMovement.GetAttributeValue<Guid>("initiumc_stockmovementid"),
                    MovementType = stockMovement.GetAttributeValue<OptionSetValue>("initiumc_movementtype").Value,
                    Quantity = stockMovement.GetAttributeValue<int>("initiumc_quantity"),
                    ProductId = product.Id,
                    ProductName = product.ProductName,
                    Date = DateTime.Parse(stockMovement.GetAttributeValue<DateTime>("initiumc_date").ToString())
                });
            }

            return stockMovements;
        }

        public StockMovementDto GetStockMovementByIdAsync(Guid id)
        {
            var myStockMovement = _stockMovementRepository.Get(id);
            StockMovementDto stockMovementDto = new StockMovementDto()
            {
                Id = myStockMovement.GetAttributeValue<Guid>("initiumc_stockmovementid"),
                ProductId = myStockMovement.GetAttributeValue<EntityReference>("initiumc_relatedproduct").Id,
                MovementType = myStockMovement.GetAttributeValue<OptionSetValue>("initiumc_movementtype").Value,
                Quantity = myStockMovement.GetAttributeValue<int>("initiumc_quantity"),
                Date = DateTime.Parse(myStockMovement.GetAttributeValue<DateTime>("initiumc_date").ToString())
            };

            return stockMovementDto;
        }

        public void UpdateStockMovementAsync(StockMovementDto stockMovement)
        {
            throw new NotImplementedException();
        }
    }
}
