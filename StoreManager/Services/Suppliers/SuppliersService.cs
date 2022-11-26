using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreManager.DAL;
using StoreManager.DAL.Entities;
using StoreManager.ViewModels.Suppliers;
using System.Collections.Generic;
using System.Linq;

namespace StoreManager.Services.Suppliers
{
    public class SuppliersService : ISuppliersService
    {
        private StoreManagerDbContext db;
        private IMapper mapper;

        public SuppliersService(StoreManagerDbContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public ICollection<AllSuppliersViewModel> All()
        {
            var Suppliers = this.db.Suppliers.ToList();
            var SuppliersViewModels = new List<AllSuppliersViewModel>();
            foreach (var item in Suppliers)
            {
                SuppliersViewModels.Add(this.mapper.Map<Supplier, AllSuppliersViewModel>(item));
            }
            return SuppliersViewModels;
        }

        public void CreateSupplier(SupplierViewModel supplier)
        {
            Supplier Supplier = this.mapper.Map<SupplierViewModel, Supplier>(supplier);
            this.db.Suppliers.Add(Supplier);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var Supplier = this.db.Suppliers.FirstOrDefault(x => x.Id == id);
            this.db.Suppliers.Remove(Supplier);
        }

        public SupplierViewModel Details(int Id)
        {
            var Supplier = this.mapper.Map<Supplier, SupplierViewModel>(this.db.Suppliers.FirstOrDefault(x => x.Id == Id));
            return Supplier;
        }

        public void Edit(SupplierEditViewModel supplier)
        {
            var Supplier = this.db.Suppliers.FirstOrDefault(x => x.Id == supplier.Id);
            this.db.Entry(Supplier).State = EntityState.Detached;
            Supplier = this.mapper.Map<SupplierEditViewModel, Supplier>(supplier);
            this.db.Update(Supplier);
            this.db.SaveChanges();
        }

        public SupplierEditViewModel GetById(int id)
        {
            var Supplier = this.mapper.Map<Supplier,SupplierEditViewModel>(this.db.Suppliers.FirstOrDefault(x => x.Id == id));
            return Supplier;
        }
    }
}
