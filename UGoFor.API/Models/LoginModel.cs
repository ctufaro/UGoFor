using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UGoFor.API.DAL;

namespace UGoFor.API.Models
{
    public class LoginModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int CheckCredentials(LoginModel userCredentials)
        {
            return new LoginDAL().CheckCredentials(userCredentials);
        }
    }
}