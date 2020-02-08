namespace CircularManagementSystem.Entity
{
    public class Employee
    {
        protected string employeeName;
        protected string employeePhoneNumber;
        protected string employeeEmail;
        protected string employeeId;
        protected string employeePassword;
        protected int department_id;
        protected int manager_id;
        protected string employeeDesignation;
        public Employee(string name,string phoneNumber,string email,string password,int manager_id,int department_id,string designation)
        {
            employeeName = name;
            employeePhoneNumber = phoneNumber;
            this.department_id = department_id;
            this.manager_id = manager_id;
            employeeDesignation = designation;
            employeeEmail = email;
            employeePassword = password;
        }
    }
}
