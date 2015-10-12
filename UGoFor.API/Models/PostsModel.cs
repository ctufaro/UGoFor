using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UGoFor.API.DAL;

namespace UGoFor.API.Models
{
    public class PostsModel : IFromDataReader<PostsModel>
    {
        public int UserId { get; set; }
        public int? PostId { get; set; }
        public string ProfilePicURL { get; set; }
        public string SmallComment { get; set; }
        public string TimePosted { get; set; }
        public string PostedImage { get; set; }
        public string BigComment { get; set; }
        public string Location { get; set; }
        public string Username { get; set; }
        public string Filter { get; set; }
        public string Guid { get; set; }

        public PostsModel FromDataReader(IDataReader dr)
        {
            PostsModel postsModel = new PostsModel();
            postsModel.BigComment = dr["Comment"] is DBNull ? null : dr["Comment"].ToString();
            postsModel.PostId = dr["PostId"] is DBNull ? null : dr["PostId"] as Int32?;
            postsModel.ProfilePicURL = dr["ProfileUrl"] is DBNull ? null : dr["ProfileUrl"].ToString();
            postsModel.SmallComment = dr["ShortComment"] is DBNull ? null : dr["ShortComment"].ToString();
            postsModel.PostedImage = dr["ImageURL"] is DBNull ? null : dr["ImageURL"].ToString();
            postsModel.TimePosted = dr["Created"] is DBNull ? null : RelativeTime(dr["Created"].ToString());
            postsModel.Location = dr["Location"] is DBNull ? null : dr["Location"].ToString();
            postsModel.Username = dr["Username"] is DBNull ? null : dr["Username"].ToString();
            postsModel.Filter = dr["Filter"] is DBNull ? null : dr["Filter"].ToString();
            postsModel.Guid = dr["Guid"] is DBNull ? null : dr["Guid"].ToString();
            return postsModel;
        }

        [Obsolete("InsertPost is deprecated, please use UpdatePhotoPost instead.")]
        public PostsModel InsertPost(PostsModel sentPost)
        {
            return new PostsDAL().InsertPost(sentPost);
        }

        public void InsertPhotoPost(PostsModel photoPost)
        {
            new PostsDAL().InsertPhotoPost(photoPost);
        }

        public void UpdatePhotoPost(PostsModel photoPost)
        {
            new PostsDAL().UpdatePhotoPost(photoPost);
        }

        public List<PostsModel> SelectAllUsersPosts()
        {
            return new PostsDAL().SelectAllUsersPosts();
        }

        public string RelativeTime(string timePosted)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            DateTime yourDate = DateTime.Parse(timePosted);

            var ts = new TimeSpan(DateTime.UtcNow.Ticks - yourDate.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
            {
                return ts.Seconds + "s";
            }
            if (delta < 2 * MINUTE)
            {
                return "1m";
            }
            if (delta < 45 * MINUTE)
            {
                return ts.Minutes + "m";
            }
            if (delta < 90 * MINUTE )
            {
                return "1h";
            }
            if (delta < 24 * HOUR)
            {
                return ts.Hours + "h";
            }
            if (delta < 48 * HOUR)
            {
                return "1d";
            }
            if (delta < 30 * DAY)
            {
                return ts.Days + "d";
            }
            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months + "m";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years + "y";
            }
        }
    }
}
