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

        public List<PostsModel> SelectAllSampleUsersPosts()
        {
            List<PostsModel> lp = new List<PostsModel>();

            lp.Add(new PostsModel
            {
                PostId = 0,
                ProfilePicURL = "../Content/img/profile2.jpg",
                SmallComment = "Chicken Cutlet on a hero with American, extra mayo, lettuce, S&P",
                TimePosted = "3d",
                PostedImage = "../Content/img/burger.jpg",
                BigComment = "From the deli on 51st between 6th and 7th avenue, across from UBS."
            });

            lp.Add(new PostsModel
            {
                PostId = 1,
                ProfilePicURL = "../Content/img/profile1.jpg",
                SmallComment = "Grande Iced Black Eye",
                TimePosted = "6d",
                PostedImage = "../Content/img/coffee.jpg",
                BigComment = "Any Starbucks in the Midtown area with a wait less than 30 minutes"
            });

            lp.Add(new PostsModel
            {
                PostId = 2,
                ProfilePicURL = "../Content/img/profile3.jpg",
                SmallComment = "Chicken Nuggets, Cheese Slices, Almond Milk!",
                TimePosted = "2d",
                PostedImage = "../Content/img/nuggets.jpg",
                BigComment = "Specifically Dinosaur chicken nuggets and the almond milk best be cold."
            });

            lp.Add(new PostsModel
            {
                PostId = 3,
                ProfilePicURL = "../Content/img/profile4.jpg",
                SmallComment = "Rosie's Nuggets and my own puke",
                TimePosted = "2d",
                PostedImage = "../Content/img/dogfood.jpg",
                BigComment = "Hard boiled eggs (the yolks), sesame seed bagels, dental floss, a bird."
            });

            return lp;
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
