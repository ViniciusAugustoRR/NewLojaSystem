using LojaSystem.Helpers;
using LojaSystem.Models;
using Microsoft.Data.SqlClient;

namespace LojaSystem.DAO
{
    public class LoginDAO
    {
        private ConnHelper _Connection;


        public LoginDAO(string ConnectionString)
        {
            _Connection = new ConnHelper(ConnectionString);
        }

        public bool VerifyLogin(string user, string password)
        {
            Responsavel resp = new Responsavel();
            List<SqlParameter> parameters = new List<SqlParameter>();
            string query = "exec LS_LOGIN_VERIFY @USER, @PASSWORD";
            
            parameters.Add(new SqlParameter("@USER", user));
            parameters.Add(new SqlParameter("@PASSWORD", password));

            SqlDataReader reader = _Connection.ExecuteReader(query, parameters.ToArray());

            while (reader.Read())
            {
                try
                {
                    

                }
                catch(Exception e)
                {
                    throw e;
                }
            }

            return false; 
        }


    }

}
