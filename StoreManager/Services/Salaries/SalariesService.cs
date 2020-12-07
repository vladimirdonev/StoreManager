using AutoMapper;
using StoreManager.Data;
using StoreManager.ViewModels.Salaries;
using StoreManager.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StoreManager.Services.Salaries
{
    public class SalariesService : ISalariesService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public SalariesService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public int CreateSalary(EmployeeSalaryInputModel model)
        {
            var Salary = this.mapper.Map<EmployeeSalaryInputModel, Salary>(model);
            this.db.Salaries.Add(Salary);
            this.db.SaveChanges();
            var StoreId = this.db.Users.Where(x => x.Id == model.UserId).FirstOrDefault();
            return StoreId.UsersStore.StoreId;
        }

        public int EditSalary(EmployeeSalaryInputModel model)
        {
            var Salary = this.db.Salaries.Where(x => x.UserId == model.UserId).FirstOrDefault();
            Salary.EmployeeSalary = model.Salary;
            this.db.Entry(Salary).State = EntityState.Detached;
            this.db.Update(Salary);
            this.db.SaveChanges();
            return Salary.User.UsersStore.StoreId;
        }

        public EmployeeSalaryInputModel FindById(string UserId)
        {
            var Salary = this.db.Salaries.Where(x => x.UserId == UserId).FirstOrDefault();

            var salary = this.mapper.Map<Salary, EmployeeSalaryInputModel>(Salary);

            return salary;
        }
    }
}
