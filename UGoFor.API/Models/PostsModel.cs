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
        public int? PostId { get; set; }
        public string ProfilePicURL { get; set; }
        public string SmallComment { get; set; }
        public string TimePosted { get; set; }
        public string PostedImage { get; set; }
        public string BigComment { get; set; }
        public string Location { get; set; }

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
            return postsModel;
        }

        public void InsertPost(PostsModel sentPost)
        {
            new PostsDAL().InsertPost(sentPost);
        }

        public List<PostsModel> SelectAllUsersPosts()
        {
            return new PostsDAL().SelectAllUsersPosts();
        }

        public List<PostsModel> SelectAllSampleUsersPosts()
        {
            return new PostsDAL().SelectAllSampleUsersPosts();
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
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            }
            if (delta < 2 * MINUTE)
            {
                return "a minute ago";
            }
            if (delta < 45 * MINUTE)
            {
                return ts.Minutes + " minutes ago";
            }
            if (delta < 90 * MINUTE )
            {
                return "an hour ago";
            }
            if (delta < 24 * HOUR)
            {
                return ts.Hours + " hours ago";
            }
            if (delta < 48 * HOUR)
            {
                return "yesterday";
            }
            if (delta < 30 * DAY)
            {
                return ts.Days <= 1 ? "one day ago" : ts.Days + " days ago";
            }
            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }
    }
}
