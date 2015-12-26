using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UGoFor.API.Models;

namespace UGoFor.API.DAL
{
    public class CommentsDAL : BaseDAL
    {

        public List<CommentsModel> SelectAllPostComments()
        {
            List<CommentsModel> postComments = ExecuteSPReturnData<CommentsModel>("SelectAllPostComments");
            return postComments;
        }

        public void InsertComment(CommentsModel sentComment)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@POSTID", sentComment.PostId),
                new SqlParameter("@USERID", sentComment.UserId),
                new SqlParameter("@COMMENT", sentComment.Comment),
                new SqlParameter("@LOCATION", sentComment.Location),
            };

            ExecuteSPNonReturnData("InsertComment", parameters);

        }

        public static CommentsModel GetInitPost()
        {
            return new CommentsModel
            {
                Username = "ugoforadmin",
                Comment = "Rave a Crave!",
                ProfileUrl = "img/craveprofile.jpg"
            };
        }
    }
}