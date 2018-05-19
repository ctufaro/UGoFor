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

        public int Get(string depositAddr)
        {
            return new DepositAddr().DepositAddrExists(depositAddr);
        }

        public int Post(DepositAddr depositAddr)
        {
            return new DepositAddr().InsertDepositAddr(depositAddr);
        }
    }
}
