using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using CircularManagementSystem.BL;
namespace CircularManagementSystem
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindListData();
            }
        }
        protected void BindListData()
        {
            DepartmentBL department = new DepartmentBL();
            SortedList<int, string> temp = new SortedList<int, string>(department.GetDepartment());
            departmentList.Items.Insert(0,"--Select--");
            foreach (KeyValuePair<int, string> keyValuePair in temp)
            {
                ListItem listItem = new ListItem(keyValuePair.Value ,keyValuePair.Key.ToString());
                departmentList.Items.Add(listItem);
            }
        }

        protected void Submit_Button(object sender, EventArgs e)
        {
            EmployeeBL employee = new EmployeeBL();
            string name = txtemployeename.Text;
            string phoneNumber = employeephoneNumber.Text;
            string email = txtEmailId.Text;
            string password = name.Substring(0, 1) + phoneNumber.Substring(0, 1) + name.Substring(name.Length - 1) + phoneNumber.Substring(phoneNumber.Length - 1) + phoneNumber.Substring(5, 1);
            int department = Convert.ToInt32(Convert.ToString(departmentList.SelectedItem.Value));
            int managerId = 0;
            if (Convert.ToString(managerList.SelectedItem.Value) == "CEO")
                managerId = 1;
            else if (Convert.ToString(managerList.SelectedItem.Value) == "ProjectManager")
                managerId = 2;
            string designation = empDesignation.SelectedItem.Value.ToString();
            if (employee.AddEmployees(name, phoneNumber, department, managerId, designation) == 1)
            {
                if (employee.AddLogin(email, password, name, phoneNumber, managerId) == 1)
                {
                    Response.Write("Employee Added successfully");
                }
            }

        }
    }
}