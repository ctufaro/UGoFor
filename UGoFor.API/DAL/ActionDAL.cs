using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UGoFor.API.Models;

namespace UGoFor.API.DAL
{
    public class ActionDAL : BaseDAL
    {
        public void InsertAction(ActionModel sentAction)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@USERID", sentAction.UserId),
                new SqlParameter("@ACTION", sentAction.Action),
                new SqlParameter("@VALUE", sentAction.Value),
            };

            ExecuteSPNonReturnData("InsertAction", parameters);
        }
    }
}