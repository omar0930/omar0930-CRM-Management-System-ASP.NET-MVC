using CRM.BusinessLayer.Dtos;
using CRM.BusinessLayer.Product;
using CRM.BusinessLayer.StockMovementService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEST_MVC_CRM.Models;

namespace TEST_MVC_CRM.Controllers
{
    public class StockMovementController : Controller
    {
        private readonly IStockMovementService _stockMovementService;
        private readonly IProductService _productService;

        public StockMovementController(IStockMovementService stockMovementService, IProductService productService)
        {
            _stockMovementService = stockMovementService;
            _productService = productService;
        }
        // GET: StockMovement
        public ActionResult Index()
        {
            var StockMovements = _stockMovementService.GetAllStockMovementsAsync();

            List<StockMovementViewModel> StockMovementViewModels = new List<StockMovementViewModel>();

            var AllProducts = _productService.GetAllProductsAsync();

            foreach (var stockMovement in StockMovements)
            {
                // map each stock movement to a view model
                StockMovementViewModel vm = new StockMovementViewModel()
                {
                    Id = stockMovement.Id,
                    ProductId = stockMovement.ProductId,
                    Quantity = stockMovement.Quantity,
                    Date = stockMovement.Date,
                    MovementType = stockMovement.MovementType,
                    ProductName = stockMovement.ProductName
                };
                StockMovementViewModels.Add(vm);
            }
            // return AllProducts and StockMovementViewModels to be available in the view
            ViewBag.AllProducts = AllProducts.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.ProductName
            }).ToList();
            ViewBag.MovementTypeList = new SelectList(new List<SelectListItem>
            {
                    new SelectListItem { Text = "In", Value = "1" },
                    new SelectListItem { Text = "Out", Value = "2" }
            }, "Value", "Text");

            return View("Index", StockMovementViewModels);
        }

        // GET: StockMovement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StockMovement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StockMovement/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                var Product = _productService.GetProductByIdAsync(Guid.Parse(collection["ProductId"]));

                StockMovementDto SmDto = new StockMovementDto()
                {
                    ProductId = Guid.Parse(collection["ProductId"]),
                    Quantity = Convert.ToInt32(collection["Quantity"]),
                    Date = Convert.ToDateTime(collection["Date"]),
                    MovementType = Convert.ToInt32(collection["MovementType"]),
                    ProductName = Product.ProductName,
                };

                if (Product.CurrentStock < SmDto.Quantity && SmDto.MovementType == 0)
                {
                    return Json(new { ErrorMessage = "Insufficient stock quantity." });
                }
                _stockMovementService.AddStockMovementAsync(SmDto);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StockMovement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StockMovement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StockMovement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StockMovement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
