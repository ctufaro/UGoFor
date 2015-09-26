using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UGoFor.API.Models;

namespace UGoFor.API.DAL
{
    public class SignUpDAL : BaseDAL
    {
        public int InsertNewUser(SignUpModel sentNewUser)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@USERNAME", sentNewUser.Username),
                new SqlParameter("@EMAIL", sentNewUser.Email),
                new SqlParameter("@PASSWORD", sentNewUser.Password),
                new SqlParameter("@PROFILEURL", sentNewUser.ProfilePicURL)
            };

            return ExecuteSPNonReturnData("InsertNewUser", parameters, "@NEW_IDENTITY");
        }
    }
}