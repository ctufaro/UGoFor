using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UGoFor.API.Models;

namespace UGoFor.API.DAL
{
    public class UsersDAL : BaseDAL
    {
        public List<UsersModel> SelectAllUsers()
        {
            List<UsersModel> allUsers = ExecuteSPReturnData<UsersModel>("SelectAllUsers");
            return allUsers;
        }
    }
}