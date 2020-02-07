﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CircularManagementSystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        EmployeeRepository employeeRepository = new EmployeeRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillData();
            }
        }
        protected void FillData()
        {
            DataTable employeeTable = employeeRepository.DisplayEmployee();
            employeeView.DataSource = employeeTable;
            employeeView.DataBind();
        }
        protected void EmployeeView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            int employeeId = Convert.ToInt16(employeeView.DataKeys[e.RowIndex].Values["employeeId"].ToString());
            employeeRepository.DeleteEmployee(employeeId);
            FillData();
        }
        protected void EmployeeView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            employeeView.EditIndex = e.NewEditIndex;
            FillData();
        }
        protected void EmployeeView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            employeeView.EditIndex = -1;
            FillData();
        }
        protected void EmployeeView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string txtEmployeename = (employeeView.Rows[e.RowIndex].FindControl("txtName") as TextBox).Text;
            string txtEmployeePhone =(employeeView.Rows[e.RowIndex].FindControl("txtPhone") as TextBox).Text;
            int id = Convert.ToInt16(employeeView.DataKeys[e.RowIndex].Values["employeeId"].ToString());
            employeeRepository.UpdateEmployee(id, txtEmployeePhone, txtEmployeename);
            employeeView.EditIndex = -1;
            FillData();
        }
    }
}