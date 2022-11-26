using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoreManager.DAL;
using StoreManager.Models;
using StoreManager.ViewModels.Salaries;
using StoreManager.ViewModels.Store;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.Services.Stores
{
    public class StoresService : IStoresService
    {
        private readonly StoreManagerDbContext db;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public StoresService(StoreManagerDbContext db, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public void Create(StoreInputModel store,string UserId)
        {
            var Store = new Store
            {
                Name = store.Name,
                UserId = UserId
            };

            this.db.Stores.Add(Store);
            this.db.SaveChanges();
        }

        public ICollection<AllStoresViewModel> GetAll(string UserId)
        {
            var Stores = this.db.Stores.Where(x => x.UserId == UserId).ToList();

            var StoresToDidsplay = new List<AllStoresViewModel>();

            foreach (var store in Stores)
            {
              var Store = this.mapper.Map<Store, AllStoresViewModel>(store);
                StoresToDidsplay.Add(Store);
            }

            return StoresToDidsplay;
        }

        public EditStoreViewModel FindById(int id)
        {
            var Store = this.db.Stores.Where(x => x.Id == id).FirstOrDefault();

            var store = this.mapper.Map<Store, EditStoreViewModel>(Store);

            foreach (var item in Store.Users)
            {
                store.Users.Add($"{item.User.FirstName} {item.User.LastName}");
            }

            return store;
        }


        public void EditStore(EditStoreViewModel model)
        {
            var Store = this.db.Stores.Where(x => x.Id == model.Id).FirstOrDefault();

            Store.Name = model.Name;

            this.db.Entry(Store).State = EntityState.Detached;

            this.db.Update(Store);
            this.db.SaveChanges();
        }

        public ICollection<UserInStoreViewModel> GetUsers(ICollection<ApplicationUser> users)
        {
            var AllUsers = new List<UserInStoreViewModel>();

            var Users = users.ToList();

            foreach (var user in Users)
            {
                if (IsUserInStore(user))
                {
                    var UserInStore = new UserInStoreViewModel
                    {
                        FullName = $"{user.FirstName} {user.LastName}",
                        UserId = user.Id,
                        IsSelected = true
                    };

                    AllUsers.Add(UserInStore);
                }
                else
                {
                    var UserInStore = new UserInStoreViewModel
                    {
                        FullName = $"{user.FirstName} {user.LastName}",
                        UserId = user.Id,
                        IsSelected = false
                    };

                    AllUsers.Add(UserInStore);
                }
            }

            return AllUsers;
        }

        public ICollection<AllEmployeesViewModel> GetEmployeesÍnStore(EditStoreViewModel store)
        {
            var Store = this.db.Stores.Where(x => x.Id == store.Id).FirstOrDefault();

            var Employees = new List<AllEmployeesViewModel>();

            foreach (var item in Store.Users)
            {
               var Employee = new AllEmployeesViewModel
                {
                    FullName = $"{item.User.FirstName} {item.User.LastName}",
                    ProfileImage = item.User.ProfileImg,
                    UserId = item.User.Id,
                    Salary = item.User.EmployeeSalary?.EmployeeSalary
                };
                Employees.Add(Employee);
            }

            return Employees;
        }

        public async Task<ICollection<UserInStoreViewModel>> ManageUsers(ICollection<UserInStoreViewModel> users, int Id)
        {
            

            var Users = users.ToList();

            foreach (var user in Users)
            {
                var User = this.userManager.Users.Where(x => x.Id == user.UserId).FirstOrDefault();
                if (!IsUserInStore(User) && user.IsSelected)
                {
                    var UsersStore = new UsersStore
                    {
                        UserId = user.UserId,
                        StoreId = Id,
                    };

                    this.db.UsersStores.Add(UsersStore);
                    await this.db.SaveChangesAsync();
                }
                else if(IsUserInStore(User) && !user.IsSelected)
                {
                    var UsersStore = new UsersStore
                    {
                        UserId = user.UserId,
                        StoreId = Id,
                    };

                    this.db.UsersStores.Remove(UsersStore);
                    await this.db.SaveChangesAsync();
                }
                else
                {
                    continue;
                }
            }

            return Users;
        }

        public bool IsUserInStore(ApplicationUser user)
        {
            bool IsUserInStore = false;

            if(this.db.UsersStores.Any(x => x.UserId == user.Id))
            {
                IsUserInStore = true;
            }
            else
            {
                IsUserInStore = false;
            }
            

            return IsUserInStore;
        }
    }
}
