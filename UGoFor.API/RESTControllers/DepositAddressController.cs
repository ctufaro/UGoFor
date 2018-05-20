using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UGoFor.API.Models;

namespace UGoFor.API.RESTControllers
{
    public class DepositAddressController : ApiController
    {
        public IEnumerable<DepositAddr> Get(int status)
        {
            return new DepositAddr().SelectAllDepositAddr(status);
        }

        [HttpPost]
        public string Post([FromBody] string[] submitaddr)
        {
            return new DepositAddr().InsertDepositAddr(submitaddr);
        }

        [HttpPut]
        public void Put(SimpleSend submitaddr)
        {
            new DepositAddr().UpdateDepositAddress(submitaddr);
        }
    }


}
