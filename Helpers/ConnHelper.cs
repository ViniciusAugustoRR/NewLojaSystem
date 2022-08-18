using Microsoft.Data.SqlClient;
using System.Data;

namespace LojaSystem.Helpers
{
    public class ConnHelper
    {
        private SqlConnection SqlConn;
        private string _ConnectionString;

        public ConnHelper(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            
        }

        
        public SqlDataReader ExecuteReader(string query, SqlParameter[] parameters)
        {
            SqlDataReader dr = null;
            SqlCommand cmd = new SqlCommand();
            
            try
            {
                OpenReader();
                cmd.Connection = SqlConn;
                cmd.CommandText = query;
                cmd.Parameters.AddRange(parameters);
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                if (dr != null) { dr.Close(); }
                SqlConn.Close();
                throw ex;
            }

            return dr;
        }

        public void OpenReader()
        {
            SqlConn = new SqlConnection(_ConnectionString);
            SqlConn.Open();
        }
        public void CloseReader()
        {
            SqlConn.Close();
        }

        
    }
}
