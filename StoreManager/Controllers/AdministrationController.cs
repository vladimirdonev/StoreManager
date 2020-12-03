using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreManager.ViewModels.UserRoles;
using System.Threading.Tasks;

namespace StoreManager.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> role;

        public AdministrationController(RoleManager<IdentityRole> role)
        {
            this.role = role;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return this.View();
        }

        [HttpPost]
        public async  Task<IActionResult> CreateRoleAsync(RoleInputModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await this.role.CreateAsync(role);

                if (result.Succeeded)
                {
                    return this.Redirect("/");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return this.View(model);
        }
    }
}
