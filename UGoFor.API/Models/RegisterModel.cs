using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UGoFor.API.DAL;

namespace UGoFor.API.Models
{
    public class RegisterModel
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public void InsertNewUser(RegisterModel sentRegister)
        {
            new RegisterDAL().InsertNewUser(sentRegister);
        }
    }
}