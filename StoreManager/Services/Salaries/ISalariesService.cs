using StoreManager.ViewModels.Salaries;

namespace StoreManager.Services.Salaries
{
    public interface ISalariesService
    {
        public int CreateSalary(EmployeeSalaryInputModel model);

        public int EditSalary(EmployeeSalaryInputModel model);

        public EmployeeSalaryInputModel FindById(string UserId);
    }
}
