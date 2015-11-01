using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UGoFor.API.Models;

namespace UGoFor.API.RESTControllers
{
    public class LoginController : ApiController
    {
        // POST: api/Login
        public int Post(LoginModel userCredentials)
        {
            return new LoginModel().CheckCredentials(userCredentials);
        }
    }
}
