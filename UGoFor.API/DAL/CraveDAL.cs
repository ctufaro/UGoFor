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
            //SqlParameter[] parameters = new SqlParameter[]
            //{
            //    new SqlParameter("@USERID", crave.UserId),
            //    new SqlParameter("@SHORTCOMMENT", photoPost.SmallComment),
            //    new SqlParameter("@COMMENT", photoPost.BigComment),
            //    new SqlParameter("@LOCATION", photoPost.Location),
            //    new SqlParameter("@GUID", photoPost.Guid),
            //};

            //ExecuteSPNonReturnData("InsertUserCrave", parameters);
        }
    }
}