using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreManager.Services.Suppliers;
using StoreManager.ViewModels.Suppliers;

namespace StoreManager.Controllers
{
    [Authorize]
    [Authorize(Roles = "Owner,Employee")]
    public class SuppliersController : Controller
    {
        private ISuppliersService suppliers;

        public SuppliersController(ISuppliersService suppliers)
        {
            this.suppliers = suppliers;
        }

        public IActionResult All()
        {
            var Suppliers = this.suppliers.All();
            return this.View(Suppliers);
        }
        
        public IActionResult Edit(int Id)
        {
            var Supplier = this.suppliers.GetById(Id);
            return this.View(Supplier);
        }

        [HttpPost]
        public IActionResult Edit(SupplierEditViewModel supplier)
        {
            if (!ModelState.IsValid)
            {
                return this.View(supplier);
            }
            this.suppliers.Edit(supplier);
            return this.Redirect("/Suppliers/All");
        }

        public IActionResult Delete(int Id)
        {
            this.suppliers.Delete(Id);
            return this.Redirect("/Suppliers/All");
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(SupplierViewModel supplier)
        {

            if (!ModelState.IsValid)
            {
                return this.View(supplier);
            }

            this.suppliers.CreateSupplier(supplier);
            return this.Redirect("/Suppliers/All");
        }

        public IActionResult Details(int id)
        {
            var Supplier = this.suppliers.Details(id);
            return this.View(Supplier);
        }
    }
}
