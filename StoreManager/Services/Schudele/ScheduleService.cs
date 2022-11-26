using Microsoft.EntityFrameworkCore;
using StoreManager.DAL;
using StoreManager.DAL.Entities;
using StoreManager.Services.Stores;
using StoreManager.ViewModels.Schudele;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreManager.Services.Schudele
{
    public class ScheduleService : IScheduleService
    {
        private readonly StoreManagerDbContext db;
        private readonly IStoresService service;

        public ScheduleService(StoreManagerDbContext db, IStoresService service)
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
                if (this.service.IsUserInStore(this.db.Users.FirstOrDefault(x => x.Id == User.UserId)))
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
            var userfullname = User[1].Remove(User[1].Length - 1,1);
            var UserId = User[0].Remove(0,1);
            var Schedule = new EmployeeSchedule
            {
                StartDate = create.StartDate,
                EndDate = create.EndDate,
                EmployeeFullName = userfullname,
                User = this.db.Users.FirstOrDefault(x => x.Id == UserId),
                UserId = UserId
            };

            this.db.EmployeesSchedules.Add(Schedule);
            this.db.SaveChanges();
        }

        public bool ISShiftAvailable(DateTime StartShift, DateTime EndShift)
        {
            var Employee = this.db.EmployeesSchedules.FirstOrDefault(x => x.StartDate == StartShift || x.EndDate == EndShift);

            if (Employee != null)
            {
                return true;
            }

            return false;
        }

        public int? IsEmployeeInShift(string Id)
        {
            var Employee = this.db.EmployeesSchedules.FirstOrDefault(x => x.UserId == Id);

            if (Employee == null)
            {
                return null;
            }

            return Employee.Id;
        }

        public EditScheduleViewModel FindById(int id)
        {
            var EmployeeSchedule =  this.db.EmployeesSchedules.FirstOrDefault(x => x.Id == id);

            EditScheduleViewModel editSchedule = new EditScheduleViewModel
            {
                Id = EmployeeSchedule.Id,
                UserId = EmployeeSchedule.UserId,
                EmployeeFullName = EmployeeSchedule.EmployeeFullName,
                EndDate = EmployeeSchedule.EndDate,
                StartDate = EmployeeSchedule.StartDate
            };

            return editSchedule;
        }

        public void Update(EditScheduleViewModel model)
        {
            var Schedule = this.db.EmployeesSchedules.FirstOrDefault(x => x.Id == model.Id);

            Schedule.UserId = model.UserId;
            Schedule.EmployeeFullName = model.EmployeeFullName;
            Schedule.EndDate = model.EndDate;
            Schedule.StartDate = model.StartDate;
            Schedule.User = this.db.Users.FirstOrDefault(x => x.Id == model.UserId);

            this.db.Entry(Schedule).State = EntityState.Detached;
            this.db.Update(Schedule);
            this.db.SaveChanges();
        }
    }
}
