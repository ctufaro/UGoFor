using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UGoFor.API.RESTControllers
{
    public class AlexaController : ApiController
    {
        // GET: api/Alexa
        public IEnumerable<string> GetFunPhrase(int id)
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Alexa/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Alexa
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Alexa/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Alexa/5
        public void Delete(int id)
        {
        }
    }
}
