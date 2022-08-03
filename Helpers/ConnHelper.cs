using Microsoft.Data.SqlClient;

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

    }
}
