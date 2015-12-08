using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UGoFor.API.Models;

namespace UGoFor.API.DAL
{
    public class CraveDAL : BaseDAL
    {
        public void InsertCrave(CraveModel crave)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@USERID", crave.UserId),
                new SqlParameter("@SHORTCOMMENT", crave.CravingAmt),
                new SqlParameter("@IMAGEURL", crave.CravingPic),
                new SqlParameter("@COMMENT", crave.CravingText),
                new SqlParameter("@LOCATION", crave.Location),
                new SqlParameter("@TYPE", crave.Type)
            };

            ExecuteSPNonReturnData("InsertUserPost", parameters);
        }
    }
}