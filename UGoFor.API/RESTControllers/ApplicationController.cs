using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UGoFor.API.Models;

namespace UGoFor.API.RESTControllers
{
    public class ApplicationController : ApiController
    {
        // GET: api/Application/1
        public string Get(int id)
        {
            return new ApplicationModel().SelectApplicationSetting(id).Value;
        }
    }
}
