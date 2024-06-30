using DocumentSharing.Common;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DocumentSharing.DAL
{
    public class DocumentDAO
    {
        public DataTable GetDocument(int row)
        {
            ConnectDB.ConnectDatabase();
            SqlConnection conn = ConnectDB.conMyConnection;
            string query = $@"DECLARE @pageIndex INT = {row};
                                DECLARE @rowPage INT = 5;
                                DECLARE @start INT = @pageIndex;
                                DECLARE @end INT = @rowPage;
                                IF @pageIndex > 1
                                begin
	                                set @start = (@pageIndex - 1) * @rowPage + 1;
	                                set @end = @rowPage * @pageIndex;
                                end
                                SELECT *
                                FROM (
                                    SELECT 
		                            ROW_NUMBER() OVER (ORDER BY DocId) AS RowNum,
		                            DocId, 
                                    DocName, 
                                    DocCategory, 
                                    DocUrl, 
                                    DocStatus, 
                                    UserId, 
                                    SubjectId
                                    FROM Document
                                ) AS _row
                                WHERE _row.RowNum BETWEEN @start AND @end";  
                                //Gọi Stored: EXEC sp_GetDataPaging {row}, 5
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            return dt;
        }

        public int RowCountDocument()
        {
            ConnectDB.ConnectDatabase();
            SqlConnection conn = ConnectDB.conMyConnection;
            string query = @"SELECT COUNT(1) FROM Document";
            SqlCommand cmd = new SqlCommand(query, conn);
            int rowCount = (int)cmd.ExecuteScalar();
            return rowCount;
        }

        public int DeleteDoc(string id)
        {
            int result = 0;
            try
            {
                ConnectDB.ConnectDatabase();
                SqlConnection conn = ConnectDB.conMyConnection;
                string query = @"DELETE FROM Document WHERE DocId = @DocId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DocId", id);
                result = cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            return result;
        }
    }
}
