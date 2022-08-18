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

        public Responsavel VerifyLogin(string user, string password)
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
                    resp.IdResponsavel = int.TryParse(reader["IdResponsavel"].ToString(), out int r) ? r : 0;
                    resp.NivelResponsavelId = int.TryParse(reader["NivelResponsavelId"].ToString(), out int n)? n : 0;
                    resp.Nome = reader["Nome"].ToString();
                }
                catch (Exception)
                {
                    _Connection.CloseReader();
                    throw;
                }
            }
            _Connection.CloseReader();
            return resp; 
        }


    }

}
