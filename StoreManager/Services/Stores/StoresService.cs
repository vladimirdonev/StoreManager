using StoreManager.Data;
using StoreManager.Models;
using StoreManager.ViewModels;
using System;

namespace StoreManager.Services.Stores
{
    public class StoresService : IStoresService
    {
        private readonly ApplicationDbContext db;

        public StoresService(ApplicationDbContext db)
        {
            this.db = db;
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
    }
}
