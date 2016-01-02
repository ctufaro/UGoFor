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

        public UsersModel FromDataReader(System.Data.IDataReader dr)
        {
            UsersModel usersModel = new UsersModel();
            usersModel.Id = dr["Id"] is DBNull ? null : dr["Id"] as Int32?;
            usersModel.UserName = dr["UserName"] is DBNull ? null : dr["UserName"].ToString();
            usersModel.ProfileUrl = dr["ProfileUrl"] is DBNull ? null : dr["ProfileUrl"].ToString();
            return usersModel;
        }

        public List<UsersModel> SelectAllUsers()
        {
            return new UsersDAL().SelectAllUsers();
        }
    }
}