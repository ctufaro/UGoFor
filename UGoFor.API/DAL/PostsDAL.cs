using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UGoFor.API.Models;

namespace UGoFor.API.DAL
{
    public class PostsDAL : BaseDAL
    {
        public PostsDAL(string connection = ""): base((string.IsNullOrEmpty(connection)) ? "" : connection)
        {
        }

        public List<PostsModel> SelectAllUsersPosts()
        {
            List<PostsModel> usersPosts = ExecuteSPReturnData<PostsModel>("SelectAllUsersPosts");
            return usersPosts.Take(30).ToList();
        }

        [Obsolete("InsertPost is deprecated, please use UpdatePhotoPost instead.")]
        public PostsModel InsertPost(PostsModel sentPost)
        {
            string[] sampleFoods = new string[] { "burger.jpg", "coffee.jpg", "nuggets.jpg", "dogfood.jpg" };
            string imageURL = "http://ugoforweb.azurewebsites.net/www/img/" + sampleFoods[new Random(Guid.NewGuid().GetHashCode()).Next(0,4)];

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@USERID", sentPost.UserId),
                new SqlParameter("@SHORTCOMMENT", sentPost.SmallComment),
                new SqlParameter("@IMAGEURL", imageURL),
                new SqlParameter("@COMMENT", sentPost.BigComment),
                new SqlParameter("@LOCATION", sentPost.Location),
            };

            var postedUser = ExecuteSPReturnData<PostsModel>("InsertUserPost", parameters).First();

            return new PostsModel { ProfilePicURL = postedUser.ProfilePicURL, 
                                    SmallComment = sentPost.SmallComment, 
                                    TimePosted = "1s",
                                    PostedImage = imageURL, 
                                    BigComment = sentPost.BigComment,
                                    Username = postedUser.Username
                                  };
        }

        public void InsertPhotoPost(PostsModel photoPost)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@USERID", photoPost.UserId),
                new SqlParameter("@IMAGEURL", photoPost.PostedImage),
                new SqlParameter("@FILTER", photoPost.Filter),
                new SqlParameter("@GUID", photoPost.Guid),
            };

            ExecuteSPNonReturnData("InsertPhotoPost", parameters);
        }

        public void UpdatePhotoPost(PostsModel photoPost)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@USERID", photoPost.UserId),
                new SqlParameter("@SHORTCOMMENT", photoPost.SmallComment),
                new SqlParameter("@COMMENT", photoPost.BigComment),
                new SqlParameter("@LOCATION", photoPost.Location),
                new SqlParameter("@GUID", photoPost.Guid),
            };

            ExecuteSPNonReturnData("UpdateUserPost", parameters);
        }
    }
}
