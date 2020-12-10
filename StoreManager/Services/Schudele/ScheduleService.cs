using StoreManager.Data;
using StoreManager.Models;
using StoreManager.Services.Stores;
using StoreManager.ViewModels.Schudele;
using StoreManager.ViewModels.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.Services.Schudele
{
    public class ScheduleService : IScheduleService
    {
        private readonly ApplicationDbContext db;
        private readonly IStoresService service;

        public ScheduleService(ApplicationDbContext db, IStoresService service)
        {
            this.db = db;
            this.service = service;
        }

        public ICollection<EmployeesSchedulesViewModel> AllEmployees(int Id)
        {
            var Employees = new List<EmployeesSchedulesViewModel>();


            var EmployeesInStore = this.db.EmployeesSchedules.ToList();

            foreach (var User in EmployeesInStore)
            {
                var Employee = new EmployeesSchedulesViewModel
                {
                    Id = User.Id,
                    UserId = User.UserId,
                    EmployeeFullName = $"{User.User.FirstName} {User.User.LastName}",
                    StartDate = User.StartDate,
                    EndDate = User.EndDate
                };

                Employees.Add(Employee);
            }

            return Employees;
        }

        public CreateScheduleViewModel GetCreate(int Id)
        {
            var Store = this.service.FindById(Id);

            var Employees = this.service.GetEmployeesÍnStore(Store);

            var EmployeesInStore = new CreateScheduleViewModel();

            foreach (var employee in Employees)
            {
                EmployeesInStore.Users.Add(employee.UserId, employee.FullName);
            }

            return EmployeesInStore;
        }
        public void CreateSchedule(CreateScheduleViewModel create, string UsersTemplate)
        {
            var User = UsersTemplate.Split(", ");
            var userfullname = User[1].Remove(User[1].Length - 1);
            var userid = User[0].Remove(0,1);
            var Schedule = new EmployeeSchedule
            {
                StartDate = create.StartDate,
                EndDate = create.EndDate,
                EmployeeFullName = User[1].TrimEnd(),
                User = this.db.Users.FirstOrDefault(x => x.Id == userid),
                UserId = User[0].TrimStart()
            };

            this.db.EmployeesSchedules.Add(Schedule);
            this.db.SaveChanges();
        }
    }
}
