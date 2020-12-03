using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManager.Data;
using StoreManager.Models;
using StoreManager.Services.Users;
using StoreManager.ViewModels.UserRoles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager, IMapper mapper, 
            UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.userManager = userManager;
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

                IdentityResult result = await this.roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return this.Redirect("/Administration/ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await this.roleManager.FindByIdAsync(id);

            await this.roleManager.DeleteAsync(role);

            return this.RedirectToAction("ListRoles");
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = this.roleManager.Roles.ToList();

            var Roles = new List<AllRolesViewModel>();

            foreach (var role in roles)
            {
                var Role = this.mapper.Map<IdentityRole, AllRolesViewModel>(role);
                Roles.Add(Role);
            }

            return this.View(Roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRoleAsync(string id)
        {
            var role = await this.roleManager.FindByIdAsync(id);

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                Name = role.Name,
            };

            var UsersInCurrentRole = await this.userManager.GetUsersInRoleAsync(role.Name);

            foreach (var User in UsersInCurrentRole)
            {
                var FullName = $"{User.FirstName} {User.LastName}";
                model.Users.Add(FullName);
            }

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            role.Name = model.Name;

            var result = await this.roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return this.RedirectToAction("ListRoles");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return this.View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string id)
        {
            this.ViewBag.id = id;

            var role = await this.roleManager.FindByIdAsync(id);

            var model = new List<UserRoleViewModel>();

            foreach (var user in this.userManager.Users.ToList())
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    FullName = $"{user.FirstName} {user.LastName}"
                };

                if (await this.userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

              

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model,string roleId)
        {
            var role = await this.roleManager.FindByIdAsync(roleId);

            for (int i = 0; i < model.Count; i++)
            {
                var user = await this.userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;
                if (model[i].IsSelected && !(await this.userManager.IsInRoleAsync(user,role.Name)))
                {
                    result = await this.userManager.AddToRoleAsync(user, role.Name);
                }
                else if(!model[i].IsSelected && await this.userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await this.userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return this.RedirectToAction("EditRole", new { id = roleId });
                }
            }

            return this.RedirectToAction("EditRole", new { id = roleId });
        }
    }
}
