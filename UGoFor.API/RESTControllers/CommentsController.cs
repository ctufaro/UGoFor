using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UGoFor.API.Models;

namespace UGoFor.API.Controllers
{
    public class CommentsController : ApiController
    {
        // GET: api/Comments/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Comments
        public CommentsList Post(CommentsModel sentComment)
        {
            CommentsList commentsList = new CommentsList();
            commentsList.PostComments = new CommentsModel().InsertComment(sentComment);
            return commentsList;
        }
    }

    public class CommentsList
    {
        public List<CommentsModel> PostComments { get; set; }
    }
}
