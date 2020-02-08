using System;
using System.Data;
using System.Web.UI.WebControls;
using CircularManagementSystem.BL;
namespace CircularManagementSystem
{
    public partial class DepartmentGridView : System.Web.UI.Page
    {
         DepartmentBL department = new DepartmentBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                FillData();
            }
        }
        protected void FillData()
        {
            DataTable employeeTable = department.DisplayDepartment();
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
            department.DeleteDepartment(departmentId);
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
            department.UpdateDepartment(id, txtDepartmentName);
            DepartmentView.EditIndex = -1;
            FillData();
        }
        protected void LbInsert_Click(object sender, EventArgs e)
        {
            string departmentName= (DepartmentView.FooterRow.FindControl("txtDepartmentNameFooter") as TextBox).Text;
            department.InsertDepartment(departmentName);
            DepartmentView.EditIndex = -1;
            FillData();
        }
    }
}