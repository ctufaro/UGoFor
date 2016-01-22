using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UGoFor.API.Models;

namespace UGoFor.API.DAL
{
    public class ProfileDAL : BaseDAL
    {
        public List<ProfileModel> SelectUserProfileStats(int userId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@USERID", userId),
            };

            List<ProfileModel> userProfileStats = ExecuteSPReturnData<ProfileModel>("SelectUsersProfileStats", parameters);
            return userProfileStats;
        }
    }
}