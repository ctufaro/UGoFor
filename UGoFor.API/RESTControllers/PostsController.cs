using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UGoFor.API.Models;

namespace UGoFor.API.Controllers
{
    public class PostsController : ApiController
    {
        //IMPORTANT - IF THIS GETS SLOW WE MAY NEED TO STOP CALLING SelectAllUsersPosts()
        
        private int batchsize = 15;
        
        // GET: api/Posts
        public IEnumerable<PostsModel> Get()
        {
            return new PostsModel().SelectAllUsersPosts().Take(batchsize).ToList();
        }

        // GET: api/Posts/5
        public IEnumerable<PostsModel> Get(int id, int direction)
        {
            if (direction == 0)
            {
                return new PostsModel().SelectAllUsersPosts().Where(x => x.PostId < id).Take(batchsize).ToList();
            }
            else
            {
                return new PostsModel().SelectAllUsersPosts().Where(x => (x.PostId > id));
            }
            
        }

        // POST: api/Posts
        public void Post(PostsModel sentPost)
        {
            new PostsModel().UpdatePhotoPost(sentPost);
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
