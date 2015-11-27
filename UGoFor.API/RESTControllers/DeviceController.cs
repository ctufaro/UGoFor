using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UGoFor.API.Models;

namespace UGoFor.API.RESTControllers
{
    public class DeviceController : ApiController
    {
        // GET: api/Device
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Device/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Device
        public void Post(DeviceModel device)
        {
            return new DeviceModel().CheckDevice(device);
        }

        // PUT: api/Device/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Device/5
        public void Delete(int id)
        {
        }
    }
}
