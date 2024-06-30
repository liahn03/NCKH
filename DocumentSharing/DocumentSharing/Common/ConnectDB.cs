using Microsoft.Data.SqlClient;

namespace DocumentSharing.Common
{
    public class ConnectDB
    {
        public static SqlConnection conMyConnection;
        public static void ConnectDatabase()
        {
            string strConn = @"Data Source=.;Initial Catalog=DocumentSharing;Integrated Security=True;TrustServerCertificate=True;";
            conMyConnection = new SqlConnection();
            conMyConnection.ConnectionString = strConn;
            conMyConnection.Open();
        }
    }
}
