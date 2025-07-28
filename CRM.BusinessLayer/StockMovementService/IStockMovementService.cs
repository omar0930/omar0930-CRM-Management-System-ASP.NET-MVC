using CRM.BusinessLayer.Dtos;
using CRM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.StockMovementService
{
    public interface IStockMovementService
    {
        List<StockMovementDto> GetAllStockMovementsAsync();
        StockMovementDto GetStockMovementByIdAsync(Guid id);
        void AddStockMovementAsync(StockMovementDto stockMovement);
        void UpdateStockMovementAsync(StockMovementDto stockMovement);
        void DeleteStockMovementAsync(StockMovementDto stockMovement);
    }
}
