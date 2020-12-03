using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreManager.Models;
using StoreManager.Services.Stores;
using StoreManager.Services.Users;
using StoreManager.ViewModels;

namespace StoreManager.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoresService service;
        private readonly UserManagerExtend<ApplicationUser> userManager;

        public StoreController(IStoresService service, UserManagerExtend<ApplicationUser> userManager)
        {
            this.service = service;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult CreateStore()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult CreateStore(StoreInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Store/CreateStore");
            }

            var UserId = this.userManager.GetUserId(this.User);

            this.service.Create(model, UserId);

            return this.Redirect("/");
        }
    }
}
