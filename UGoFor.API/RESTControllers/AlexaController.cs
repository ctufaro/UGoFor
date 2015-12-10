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
            retval.response.outputSpeech.text = "Kathleen, you are my world entire, I love you more than bees love honey, more than Greta likes licking her paws, more than Chris from next door likes smoking marijuana, more than the Earth. I'm always thinking about you, remember that.";
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
        public AlexaResponse()
        {
            this.response = new AlexaResponseObj();
        }
    }
    public class AlexaResponseObj
    {
        public AlexaOutputSpeechObj outputSpeech { get; set; }
        public bool shouldEndSession { get; set; }
        public AlexaResponseObj()
        {
            this.outputSpeech = new AlexaOutputSpeechObj();
        }
    }
    public class AlexaOutputSpeechObj
    {
        public string type { get; set; }
        public string text { get; set; }
    }

}
