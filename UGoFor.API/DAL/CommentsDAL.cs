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
    }
}