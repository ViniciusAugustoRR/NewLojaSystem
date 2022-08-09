using Microsoft.Data.SqlClient;
using System.Data;

namespace LojaSystem.Helpers
{
    public class ConnHelper
    {
        public SqlConnection SqlConn;
        public string _ConnectionString;

        public ConnHelper(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            SqlConn = new SqlConnection(_ConnectionString);
        }

        
        public SqlDataReader ExecuteReader(string query, SqlParameter[] parameters)
        {
            SqlDataReader dr = null;
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.Parameters.AddRange(parameters);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                conn.Close();
            }
            catch (Exception ex)
            {
                if (dr != null) { dr.Close(); }
                conn.Close();
                throw ex;
            }

            return dr;
        }

        
    }
}
