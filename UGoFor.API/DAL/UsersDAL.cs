using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UGoFor.API.Models;

namespace UGoFor.API.DAL
{
    public class UsersDAL : BaseDAL
    {
        public List<UsersModel> SelectAllUsers(int userId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@USERID", userId),
            };

            List<UsersModel> allUsers = ExecuteSPReturnData<UsersModel>("SelectAllUsers", parameters);

            return allUsers;
        }
    }
}