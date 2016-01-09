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
        public UsersModel SelectUser(int userId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@USERID", userId),
            };

            List<UsersModel> selectUser = ExecuteSPReturnData<UsersModel>("SelectUser", parameters);

            return selectUser.First();
        }

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