using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UGoFor.API.Models;

namespace UGoFor.API.DAL
{
    public class RegisterDAL : BaseDAL
    {
        public void InsertNewUser(RegisterModel sentNewUser)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                //new SqlParameter("@USERID", new Random(Guid.NewGuid().GetHashCode()).Next(1,4)),
                //new SqlParameter("@SHORTCOMMENT", sentPost.SmallComment),
                //new SqlParameter("@IMAGEURL", "http://ugoforweb.azurewebsites.net/www/img/" + sampleFoods[new Random(Guid.NewGuid().GetHashCode()).Next(0,3)]),
                //new SqlParameter("@COMMENT", sentPost.BigComment),
                //new SqlParameter("@LOCATION", sentPost.Location),
            };
            ExecuteSPNonReturnData("InsertNewUser", parameters);
        }
    }
}