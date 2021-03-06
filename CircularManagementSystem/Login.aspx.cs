﻿using System;
using CircularManagementSystem.BL;
namespace CircularManagementSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            EmployeeBL employeeRepository = new EmployeeBL();
            string userId = txtUserId.Text;
            string password = Password.Text;
            string roll = employeeRepository.Login(userId, password);
            if (roll == "Admin")
            {
                Response.Redirect("AddEmployee.aspx");
            }
            else if (roll == "User")
            {
                Response.Redirect("Login Successfull");
            }
            else
            {
                Response.Write("Login Failed");
            }
        }
    }
}