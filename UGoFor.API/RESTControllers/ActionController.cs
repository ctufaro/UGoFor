using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UGoFor.API.Models;

namespace UGoFor.API.RESTControllers
{
    public class ActionController : ApiController
    {
        public void Post(ActionModel sentAction)
        {
            new ActionModel().PostAction(sentAction);
        }
    }
}
