using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UGoFor.API.Models;

namespace UGoFor.API.DAL
{
    public class LoginDAL : BaseDAL
    {
        public int CheckCredentials(LoginModel userCredentials)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@USERNAME", userCredentials.Username),
                new SqlParameter("@PASSWORD", userCredentials.Password)
            };

            return ExecuteSPNonReturnData("SelectUserLogin", parameters, "@USERID");
        }
    }
}