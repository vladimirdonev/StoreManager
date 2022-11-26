using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreManager.Models;
using StoreManager.Services.Stores;
using StoreManager.Services.Users;
using StoreManager.ViewModels.Store;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.Controllers
{
    [Authorize]
    [Authorize(Roles = "Owner")]
    public class StoreController : Controller
    {
        private readonly IStoresService service;
        private readonly UserManagerExtension<ApplicationUser> userManager;

        public StoreController(IStoresService service, UserManagerExtension<ApplicationUser> userManager)
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
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Store/CreateStore");
            }

            var UserId = this.userManager.GetUserId(this.User);

            this.service.Create(model, UserId);

            return this.Redirect("/");
        }

        [HttpGet]
        public IActionResult All()
        {
            var UserId = this.userManager.GetUserId(this.User);

            return this.View(this.service.GetAll(UserId).ToList());
        }

        [HttpGet]
        public IActionResult EditStore(int id)
        {
            var Store = this.service.FindById(id);

            return this.View(Store);
        }

        [HttpPost]
        public IActionResult EditStore(EditStoreViewModel model)
        {
            var Store = this.service.FindById(model.Id);

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.service.EditStore(model);

            return this.RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult EditUsersInStore(int id)
        {
            this.ViewBag.id = id;

            var Store = this.service.FindById(id);

            var UsersInCurrentStore = this.service.GetUsers(this.userManager.Users.ToList()).ToList();

            return this.View(UsersInCurrentStore);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInStore(ICollection<UserInStoreViewModel> Users, int Id)
        {
            await this.service.ManageUsers(Users, Id);

            return this.RedirectToAction("EditUsersInStore");
        }
    }
}
