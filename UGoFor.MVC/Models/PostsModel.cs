using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UGoFor.MVC.DAL;

namespace UGoFor.MVC.Models
{
    public class PostsModel : IFromDataReader<PostsModel>
    {
        public int? PostId { get; set; }
        public string ProfilePicURL { get; set; }
        public string SmallComment { get; set; }
        public string TimePosted { get; set; }
        public string PostedImage { get; set; }
        public string BigComment { get; set; }

        public PostsModel FromDataReader(IDataReader dr)
        {
            PostsModel postsModel = new PostsModel();
            postsModel.BigComment = dr["Comment"] is DBNull ? null : dr["Comment"].ToString();
            postsModel.PostId = dr["PostId"] is DBNull ? null : dr["PostId"] as Int32?;
            postsModel.ProfilePicURL = dr["ProfileUrl"] is DBNull ? null : dr["ProfileUrl"].ToString();
            postsModel.SmallComment = dr["ShortComment"] is DBNull ? null : dr["ShortComment"].ToString();
            postsModel.PostedImage = dr["ImageURL"] is DBNull ? null : dr["ImageURL"].ToString();
            postsModel.TimePosted = dr["Created"] is DBNull ? null : dr["Created"].ToString();
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
    }
}