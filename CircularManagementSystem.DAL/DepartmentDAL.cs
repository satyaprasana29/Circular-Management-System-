using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CircularManagementSystem.DAL
{
    public class DepartmentRepositoryDAL
    {
        DataBaseDetails baseDetails = new DataBaseDetails();
        public SortedList<int, string> GetDepartment()
        {
            SortedList<int, string> departmentDetails = new SortedList<int, string>();
            SqlConnection sqlConnection = baseDetails.ConnectionString();
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("DISPLAY_DEPARTMENT", sqlConnection);
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        departmentDetails.Add(reader.GetInt32(0), reader.GetString(1));
                    }
                }
            }
            return departmentDetails;
        }
        public DataTable DisplayDepartment()
        {
            SqlConnection sqlConnection = baseDetails.ConnectionString();
            using (SqlCommand command = new SqlCommand("DISPLAY_DEPARTMENT", sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                return dataTable;
            }
        }
        public void DeleteDepartment(int departmentId)
        {
            SqlConnection sqlConnection = baseDetails.ConnectionString();
            sqlConnection.Open();
            using (SqlCommand cmd = new SqlCommand("SP_DELETE_DEPARTMENT", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@departmentId", departmentId);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateDepartment(int id, string departmentName)
        {
            SqlConnection sqlConnection = baseDetails.ConnectionString();
            sqlConnection.Open();
            using (SqlCommand cmd = new SqlCommand("SP_UPDATE_DEPARTMENT", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@departmentId", id);
                cmd.Parameters.AddWithValue("@departmentName", departmentName);
                cmd.ExecuteNonQuery();
            }
        }
        public void InsertDepartment(string departmentName)
        {
            SqlConnection sqlConnection = baseDetails.ConnectionString();
            sqlConnection.Open();
            using (SqlCommand command = new SqlCommand("SP_INSERT_DEPARTMENT", sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@departmentName", departmentName);
                command.ExecuteNonQuery();
            }
        }
    }
}
