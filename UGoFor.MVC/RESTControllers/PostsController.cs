using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UGoFor.MVC.Models;

namespace UGoFor.MVC.Controllers
{
    public class PostsController : ApiController
    {
        // GET: api/Posts
        public IEnumerable<PostsModel> Get()
        {
            return new PostsModel().SelectAllUsersPosts();
        }

        // GET: api/Posts/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Posts
        public void Post(PostsModel sentPost)
        {
            new PostsModel().InsertPost(sentPost);
        }

        // PUT: api/Posts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Posts/5
        public void Delete(int id)
        {
        }
    }
}
