using StoreManager.ViewModels.Suppliers;
using System.Collections.Generic;

namespace StoreManager.Services.Suppliers
{
    public interface ISuppliersService
    {
        ICollection<AllSuppliersViewModel> All();

        void CreateSupplier(SupplierViewModel supplier);

        SupplierEditViewModel GetById(int id);

        void Edit(SupplierEditViewModel supplier);

        SupplierViewModel Details(int Id);

        void Delete(int id);
    }
}
