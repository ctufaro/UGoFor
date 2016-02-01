using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UGoFor.API.Models;

namespace UGoFor.API.RESTControllers
{
    public class UsersController : ApiController
    {
        [Route("api/users/{id}")]
        public IEnumerable<UsersModel> Get(int id)
        {
            return new UsersModel().SelectAllUsers(id);
        }

        [Route("api/users/getusernameexists/{name}")]
        public bool GetUsernameExists(string name)
        {
            return new UsersModel().SelectUserByName(name) != null;
        }

    }
}
