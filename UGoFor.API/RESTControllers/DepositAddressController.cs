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
        public IEnumerable<DepositAddr> Get()
        {
            return new DepositAddr().SelectAllDepositAddr();
        }

        public int Post(string submitaddr)
        {
            return new DepositAddr().InsertDepositAddr(submitaddr);
        }
    }
}
