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
            string query = @"SELECT 
                                DocId AS DocId, 
                                DocName AS DocName, 
                                DocCategory AS DocCategory, 
                                DocUrl AS DocUrl, 
                                DocStatus AS DocStatus, 
                                UserId AS UserId, 
                                SubjectId AS SubjectId 
                                FROM Document";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            return dt;
        }
    }
}
