using CircularManagementSystem.DAL;
using System.Data;

namespace CircularManagementSystem.BL
{
    public class EmployeeBL
    {
        EmployeeRepositoryDAL employee = new EmployeeRepositoryDAL();
        public DataTable DisplayEmployee()
        {
            return employee.DisplayEmployee();
        }
        public void DeleteEmployee(int employeeId)
        {
            employee.DeleteEmployee(employeeId);
        }
        public void UpdateEmployee(int id, string employeePhone, string employeeName)
        {
            employee.UpdateEmployee(id, employeePhone, employeeName);
        }
        public string Login(string userName, string password)
        {
            return employee.Login(userName, password);
        }
        public int AddEmployees(string name, string phoneNumber, int dept_id, int manager_id, string employeeDesignation)
        {
            return employee.AddEmployees(name, phoneNumber, dept_id, manager_id, employeeDesignation);
        }
        public int AddLogin(string email, string password, string name, string phoneNumber, int manager_id)
        {
            return employee.AddLogin(email, password, name, phoneNumber, manager_id);
        }
    }
}
