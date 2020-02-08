using System;
using System.Collections.Generic;
using System.Data;
using CircularManagementSystem.DAL;
namespace CircularManagementSystem.BL
{
    public class DepartmentBL
    {
        DepartmentRepositoryDAL department = new DepartmentRepositoryDAL();
        public DataTable DisplayDepartment()
        {
           return department.DisplayDepartment();
        }
        public void DeleteDepartment(int departmentId)
        {
            department.DeleteDepartment(departmentId);
        }
        public void UpdateDepartment(int id, string departmentName)
        {
            department.UpdateDepartment(id, departmentName);
        }
        public void InsertDepartment(string departmentName)
        {
            department.InsertDepartment(departmentName);
        }
        public SortedList<int, string> GetDepartment()
        {
            return department.GetDepartment();
        }
    }
}
