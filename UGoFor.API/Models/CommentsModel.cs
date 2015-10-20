using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UGoFor.API.DAL;

namespace UGoFor.API.Models
{
    public class CommentsModel : IFromDataReader<CommentsModel>
    {


        public int? Id { get; set; }
        public int? PostId { get; set; }
        public int? UserId { get; set; }
        public string Comment { get; set; }
        public string Username { get; set; }

        public CommentsModel FromDataReader(IDataReader dr)
        {
            CommentsModel commentsModel = new CommentsModel();
            commentsModel.Id = dr["Id"] is DBNull ? null : dr["Id"] as Int32?;
            commentsModel.PostId = dr["PostId"] is DBNull ? null : dr["PostId"] as Int32?;
            commentsModel.UserId = dr["UserId"] is DBNull ? null : dr["UserId"] as Int32?;
            commentsModel.Comment = dr["Comment"] is DBNull ? null : dr["Comment"].ToString();
            commentsModel.Username = dr["Username"] is DBNull ? null : dr["Username"].ToString();
            return commentsModel;
        }


        public List<CommentsModel> SelectAllPostComments()
        {
            return new CommentsDAL().SelectAllPostComments();
        }

    }


}
