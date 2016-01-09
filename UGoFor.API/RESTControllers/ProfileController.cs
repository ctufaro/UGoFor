using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UGoFor.API.Models;
namespace UGoFor.API.RESTControllers
{
    public class ProfileController : ApiController
    {
        public UsersModel Get(int id)
        {
            return new UsersModel().SelectUser(id);
        }
    }
}
