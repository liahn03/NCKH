using DocumentSharing.Common;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DocumentSharing.DAL
{
    public class DocumentDAO
    {
        public DataTable GetDocument()
        {
            ConnectDB.ConnectDatabase();
            SqlConnection conn = ConnectDB.conMyConnection;
            string query = @"SELECT RoleId AS RoleId, RoleName AS RoleName FROM AppRole";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            return dt;

        }
    }
}
