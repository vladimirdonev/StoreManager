using StoreManager.Models;
using StoreManager.ViewModels.Schudele;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreManager.Services.Schudele
{
    public interface IScheduleService
    {
        public ICollection<EmployeesSchedulesViewModel> AllEmployees(int Id);

        public CreateScheduleViewModel GetCreate(int Id);

        public void CreateSchedule(CreateScheduleViewModel create, string UsersTemplate); 
    }
}
