using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UGoFor.API.DAL;

namespace UGoFor.API.Models
{
    public class ActionModel
    {
        public int UserId { get; set; }
        public string Action { get; set; }
        public string Value { get; set; }

    }
}