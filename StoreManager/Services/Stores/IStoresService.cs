using StoreManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.Services.Stores
{
    public interface IStoresService
    {
        void Create(StoreInputModel store,string UserId);
    }
}
