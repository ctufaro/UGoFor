using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UGoFor.API.DAL;

namespace UGoFor.API.Models
{
    public class SignUpModel
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProfilePicURL { get; set; }
        public string Location { get; set; }

        public int InsertNewUser(SignUpModel sentNewUser)
        {
            return new SignUpDAL().InsertNewUser(sentNewUser);
        }
    }
}