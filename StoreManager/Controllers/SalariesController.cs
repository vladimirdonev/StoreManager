using Microsoft.AspNetCore.Mvc;
using StoreManager.Services.Salaries;
using StoreManager.Services.Stores;
using StoreManager.ViewModels.Salaries;

namespace StoreManager.Controllers
{
    public class SalariesController : Controller
    {
        private readonly IStoresService storesService;
        private readonly ISalariesService service;

        public SalariesController(IStoresService storesService,ISalariesService service)
        {
            this.storesService = storesService;
            this.service = service;
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Store = this.storesService.FindById(id);

            var Employees = this.storesService.GetEmployeesÍnStore(Store);

            return this.View(Employees);
        }

        [HttpGet]
        public IActionResult SetSalary(string UserId)
        {
            this.ViewBag.UserId = UserId;
            return this.View();
        }

        [HttpPost]
        public IActionResult SetSalary(EmployeeSalaryInputModel model)
        {
            var StoreId = this.service.CreateSalary(model);
            return this.RedirectToAction("Edit", new { id = StoreId });
        }

        [HttpGet]
        public IActionResult EditSalary(string UserId)
        {
            var Model = this.service.FindById(UserId);

            return this.View(Model);
        }

        [HttpPost]
        public IActionResult EditSalary(EmployeeSalaryInputModel model)
        {
           var StoreId = this.service.EditSalary(model);

            return this.RedirectToAction("Edit", new { id = StoreId });
        }
    }
}
