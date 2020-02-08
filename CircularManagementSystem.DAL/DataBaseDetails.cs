using System.Configuration;
using System.Data.SqlClient;

namespace CircularManagementSystem.DAL
{
    class DataBaseDetails
    {
        public SqlConnection ConnectionString()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionstring);
            return sqlConnection;
        }
    }
}
