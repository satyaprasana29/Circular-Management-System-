using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CircularManagementSystem
{
    public partial class DepartmentGridView : System.Web.UI.Page
    {
        EmployeeRepository employeeRepository = new EmployeeRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                FillData();
            }
        }
        protected void FillData()
        {
            DataTable employeeTable = employeeRepository.DisplayDepartment();
            DepartmentView.DataSource = employeeTable;
            DepartmentView.DataBind();
        }
        protected void DepartmentView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DepartmentView.EditIndex = -1;
            FillData();
        }
        protected void DepartmentView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int departmentId = Convert.ToInt16(DepartmentView.DataKeys[e.RowIndex].Values["Department_id"].ToString());
            employeeRepository.DeleteDepartment(departmentId);
            FillData();
        }
        protected void DepartmentView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DepartmentView.EditIndex = e.NewEditIndex;
            FillData();
        }
        protected void DepartmentView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string txtDepartmentName = (DepartmentView.Rows[e.RowIndex].FindControl("txtName") as TextBox).Text;
            int id = Convert.ToInt16(DepartmentView.DataKeys[e.RowIndex].Values["Department_id"].ToString());
            employeeRepository.UpdateDepartment(id, txtDepartmentName);
            DepartmentView.EditIndex = -1;
            FillData();
        }
        protected void LbInsert_Click(object sender, EventArgs e)
        {
            string departmentName= (DepartmentView.FooterRow.FindControl("txtDepartmentNameFooter") as TextBox).Text;
            employeeRepository.InsertDepartment(departmentName);
            DepartmentView.EditIndex = -1;
            FillData();
        }
    }
}