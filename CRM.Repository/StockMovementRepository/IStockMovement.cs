using CRM.Repository.Models;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Repository.StockMovementService
{
    public interface IStockMovementRepository
    {
        void Add(Entity stockMovement);
        void Update(Entity stockMovement);
        void Delete(Entity stockMovement);
        Entity Get(Guid id);
        DataCollection<Entity> GetAll();
    }
}
