using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UGoFor.API.DAL;

namespace UGoFor.API.Models
{
    public class ProfileModel : IFromDataReader<ProfileModel>
    {
        public string Action { get; set; }
        public int? Count { get; set; }

        public ProfileModel FromDataReader(IDataReader dr)
        {
            ProfileModel profileModel = new ProfileModel();
            profileModel.Action = dr["Action"] is DBNull ? null : dr["Action"].ToString();
            profileModel.Count = dr["Count"] is DBNull ? null : dr["Count"] as Int32?;
            return profileModel;
        }

        public List<ProfileModel> SelectUserProfileStats(int userId)
        {
            return new ProfileDAL().SelectUserProfileStats(userId);
        }
    }
}