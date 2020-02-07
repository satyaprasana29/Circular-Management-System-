using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CircularManagementSystem
{
    class EmployeeRepository
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public int AddEmployees(string name, string phoneNumber, int dept_id, int manager_id, string employeeDesignation)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionstring);
            string sql = "INSERT_RECORD";
            int result = 0;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                command.CommandType     = CommandType.StoredProcedure;
                SqlParameter parameter  = new SqlParameter();
                parameter.ParameterName = "@name";
                parameter.Value         = name;
                parameter.SqlDbType     = SqlDbType.VarChar;
                command.Parameters.Add(parameter);
                parameter = new SqlParameter();
                parameter.ParameterName = "@phoneNumber";
                parameter.Value = phoneNumber;
                parameter.SqlDbType = SqlDbType.VarChar;
                command.Parameters.Add(parameter);
                parameter = new SqlParameter();
                parameter.ParameterName = "@Dept_id";
                parameter.Value = dept_id;
                parameter.SqlDbType = SqlDbType.Int;
                command.Parameters.Add(parameter);
                parameter = new SqlParameter();
                parameter.ParameterName = "@manager_id";
                parameter.Value = manager_id;
                parameter.SqlDbType = SqlDbType.Int;
                command.Parameters.Add(parameter);
                parameter = new SqlParameter();
                parameter.ParameterName = "@designation";
                parameter.Value = employeeDesignation;
                parameter.SqlDbType = SqlDbType.VarChar;
                command.Parameters.Add(parameter);
                sqlConnection.Open();
                dataAdapter.InsertCommand = command;
                result = dataAdapter.InsertCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            return result;
        }
        public int AddLogin(string email, string password, string name, string phoneNumber, int manager_id)
        {
            int result = 0;
            SqlConnection sqlConnection = new SqlConnection(connectionstring);
            string sql = "INSERT_USER";
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            string query = "GET_EMPLOYEEID";
            object employeeId;
            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@name";
                sqlParameter.Value = name;
                sqlParameter.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@phoneNumber";
                sqlParameter.Value = phoneNumber;
                sqlParameter.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(sqlParameter);
                sqlConnection.Open();
                dataAdapter.SelectCommand = sqlCommand;
                employeeId = dataAdapter.SelectCommand.ExecuteScalar();
                sqlConnection.Close();
            }
            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@employeeId";
                parameter.Value = Convert.ToInt32(Convert.ToInt32(employeeId));
                parameter.SqlDbType = SqlDbType.Int;
                command.Parameters.Add(parameter);
                parameter = new SqlParameter();
                parameter.ParameterName = "@username";
                parameter.Value = email;
                parameter.SqlDbType = SqlDbType.VarChar;
                command.Parameters.Add(parameter);
                parameter = new SqlParameter();
                parameter.ParameterName = "@password";
                parameter.Value = password;
                parameter.SqlDbType = SqlDbType.VarChar;
                command.Parameters.Add(parameter);
                if (manager_id == 2)
                {
                    parameter = new SqlParameter();
                    parameter.ParameterName = "@roll";
                    parameter.Value = "User";
                    parameter.SqlDbType = SqlDbType.VarChar;
                    command.Parameters.Add(parameter);
                }
                else if (manager_id == 1)
                {
                    parameter = new SqlParameter();
                    parameter.ParameterName = "@roll";
                    parameter.Value = "Admin";
                    parameter.SqlDbType = SqlDbType.VarChar;
                    command.Parameters.Add(parameter);
                }
                sqlConnection.Open();
                dataAdapter.InsertCommand = command;
                result = dataAdapter.InsertCommand.ExecuteNonQuery();
                Console.WriteLine("Row inserted");
                sqlConnection.Close();
            }
            return result;
        }
        public SortedList<int, string> GetDepartment()
        {
            SortedList<int, string> departmentDetails = new SortedList<int, string>();
            SqlConnection sqlConnection = new SqlConnection(connectionstring);
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
        public string Login(string userName, string password)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("USER_DETAILS", sqlConnection);
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if ((reader.GetString(0) == userName) && (reader.GetString(1) == password))
                        {
                            return reader.GetString(2);
                        }
                    }
                }
            }
            return "";
        }
        public DataTable DisplayEmployee()
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            using (SqlCommand command = new SqlCommand("DISPLAY_EMPLOYEE", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                return dataTable;
            }
        }
        public void DeleteEmployee(int employeeId)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            using (SqlCommand cmd = new SqlCommand("DELETE_EMPLOYEE", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateEmployee(int id,string employeePhone,string employeeName)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            using (SqlCommand cmd = new SqlCommand("SP_UPDATE_EMPLOYEE", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@employeeId", id);
                cmd.Parameters.AddWithValue("@name", employeeName);
                cmd.Parameters.AddWithValue("@phoneNumber", employeePhone);
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable DisplayDepartment()
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            using (SqlCommand command = new SqlCommand("DISPLAY_DEPARTMENT", connection))
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
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            using (SqlCommand cmd = new SqlCommand("SP_DELETE_DEPARTMENT", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@departmentId", departmentId);
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateDepartment(int id,string departmentName)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            using (SqlCommand cmd = new SqlCommand("SP_UPDATE_DEPARTMENT", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@departmentId", id);
                cmd.Parameters.AddWithValue("@departmentName", departmentName);
                cmd.ExecuteNonQuery();
            }
        }
        public void InsertDepartment(string departmentName)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            using(SqlCommand command=new SqlCommand("SP_INSERT_DEPARTMENT", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@departmentName", departmentName);
                command.ExecuteNonQuery();
            }
        }
    }
}
