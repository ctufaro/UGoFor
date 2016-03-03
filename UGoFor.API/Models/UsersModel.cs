using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UGoFor.API.DAL;

namespace UGoFor.API.Models
{
    public class UsersModel : IFromDataReader<UsersModel>
    {
        public int? Id { get; set; }
        public string UserName { get; set; }
        public string ProfileUrl { get; set; }
        public string Email { get; set; }
        public int? Followed { get; set; }
        public int? Blocked { get; set; }

        public UsersModel FromDataReader(System.Data.IDataReader dr)
        {
            UsersModel usersModel = new UsersModel();
            usersModel.Id = dr["Id"] is DBNull ? null : dr["Id"] as Int32?;
            usersModel.UserName = dr["UserName"] is DBNull ? null : dr["UserName"].ToString();
            usersModel.ProfileUrl = dr["ProfileUrl"] is DBNull ? null : dr["ProfileUrl"].ToString();
            usersModel.Email = dr["ProfileUrl"] is DBNull ? null : dr["Email"].ToString();
            usersModel.Followed = dr["Followed"] is DBNull ? null : dr["Followed"] as Int32?;
            usersModel.Blocked = dr["Blocked"] is DBNull ? null : dr["Blocked"] as Int32?;
            return usersModel;
        }

        public UsersModel SelectUserByName(string name)
        {
            return new UsersDAL().SelectUserByName(name);
        }

        public List<UsersModel> SelectAllUsers(int userId)
        {
            return new UsersDAL().SelectAllUsers(userId);
        }

        public UsersModel SelectUser(int userid)
        {
            return new UsersDAL().SelectUser(userid);
        }
    }
}