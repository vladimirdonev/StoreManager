using StoreManager.Models;
using StoreManager.ViewModels.Schudele;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreManager.Services.Schudele
{
    public interface IScheduleService
    {
        public ICollection<EmployeesSchedulesViewModel> AllEmployees(int Id);

        public CreateScheduleViewModel GetCreate(int Id);

        public void CreateSchedule(CreateScheduleViewModel create, string UsersTemplate);

        public bool ISShiftAvailable(DateTime StartShift, DateTime EndShift);

        public int? IsEmployeeInShift(string Id);

        public EditScheduleViewModel FindById(int id);

        public void Update(EditScheduleViewModel model); 
    }
}
