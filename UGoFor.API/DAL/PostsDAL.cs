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
            return usersPosts.Take(10).ToList();
        }

        public PostsModel InsertPost(PostsModel sentPost)
        {
            string[] sampleFoods = new string[] { "burger.jpg", "coffee.jpg", "nuggets.jpg", "dogfood.jpg" };

            int userId = new Random(Guid.NewGuid().GetHashCode()).Next(1,5);
            string profileURL = string.Format("http://ugoforweb.azurewebsites.net/www/img/profile{0}.jpg",userId);
            string imageURL = "http://ugoforweb.azurewebsites.net/www/img/" + sampleFoods[new Random(Guid.NewGuid().GetHashCode()).Next(0,4)];

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@USERID", userId),
                new SqlParameter("@SHORTCOMMENT", sentPost.SmallComment),
                new SqlParameter("@IMAGEURL", imageURL),
                new SqlParameter("@COMMENT", sentPost.BigComment),
                new SqlParameter("@LOCATION", sentPost.Location),
            };
            ExecuteSPNonReturnData("InsertUserPost", parameters);

            return new PostsModel { ProfilePicURL = profileURL, 
                                    SmallComment = sentPost.SmallComment, 
                                    TimePosted = "1s",
                                    PostedImage = imageURL, 
                                    BigComment = sentPost.BigComment 
                                  };
        }
    }
}
