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
        public IEnumerable<UsersModel> Get()
        {
            return new UsersModel().SelectAllUsers();
        }
    }
}
