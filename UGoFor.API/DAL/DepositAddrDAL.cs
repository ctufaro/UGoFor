using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UGoFor.API.Models;

namespace UGoFor.API.DAL
{
    public class DepositAddrDAL : BaseDAL
    {
        public List<DepositAddr> SelectAllDepositAddr()
        {
            List<DepositAddr> depositAddresses = ExecuteSPReturnData<DepositAddr>("SelectAllDepositAddress");
            return depositAddresses;
        }

        public int DepositAddrExists(string depositAddr)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
              new SqlParameter("@DEPOSITADDR", depositAddr),
            };

            string retval = ExecuteSPReturnDataTable("SelectDepositAddressExists", parameters).Rows[0][0].ToString();
            return Int32.Parse(retval);
        }

        public void InsertDepositAddr(DepositAddr depositAddr)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SUBMITTEDADDR", depositAddr.SubmittedAddr),
                new SqlParameter("@DEPOSITADDRL", depositAddr.DepositAddress),
                new SqlParameter("@STATUS", depositAddr.Status),
            };

            ExecuteSPNonReturnData("InsertNewDepositAddress", parameters);
        }
    }
}