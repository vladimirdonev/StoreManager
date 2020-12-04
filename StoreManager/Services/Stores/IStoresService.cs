using StoreManager.Models;
using StoreManager.ViewModels.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.Services.Stores
{
    public interface IStoresService
    {
        void Create(StoreInputModel store,string UserId);

        ICollection<AllStoresViewModel> GetAll(string UserId);

        public EditStoreViewModel FindById(int id);

        public void EditStore(EditStoreViewModel model);

        public bool IsUserInStore(ApplicationUser user);

        public ICollection<UserInStoreViewModel> GetUsers(ICollection<ApplicationUser> user);

        public Task<ICollection<UserInStoreViewModel>> ManageUsers(ICollection<UserInStoreViewModel> users, int Id);
    }
}
