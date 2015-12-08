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
        // POST: api/Alexa
        public AlexaResponse PostFunPhrase(dynamic message)
        {
            AlexaResponse retval = new AlexaResponse();
            retval.version = "1.0";
            retval.response.outputSpeech.type = "PlainText";
            retval.response.outputSpeech.text = "Hello Beautiful World";
            retval.response.shouldEndSession = true;
            return retval;            
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

    public class AlexaResponse
    {
        public string version { get; set; }
        public AlexaResponseObj response { get; set; }
    }
    public class AlexaResponseObj
    {
        public AlexaOutputSpeechObj outputSpeech { get; set; }
        public bool shouldEndSession { get; set; }
    }
    public class AlexaOutputSpeechObj
    {
        public string type { get; set; }
        public string text { get; set; }
    }

}
