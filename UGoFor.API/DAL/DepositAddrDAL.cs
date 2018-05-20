using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UGoFor.API.Models;

namespace UGoFor.API.DAL
{
    public class DepositAddrDAL : BaseDAL
    {
        public List<DepositAddr> SelectAllDepositAddr(int status)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
              new SqlParameter("@STATUS", status),
            };
            List<DepositAddr> depositAddresses = ExecuteSPReturnData<DepositAddr>("SelectAllDepositAddress", parameters);
            return depositAddresses;
        }

        public int DepositAddrExists(string depositAddr)
        {
            int retval = 0;
            
            SqlParameter[] parameters = new SqlParameter[]
            {
              new SqlParameter("@DEPOSITADDR", depositAddr),
            };
            DataTable dt = ExecuteSPReturnDataTable("SelectDepositAddressExists", parameters);

            if (dt.Rows.Count == 0)
                retval = 0;
            else
                retval = Int32.Parse(dt.Rows[0][0].ToString());

            return retval;
        }

        public void InsertDepositAddr(string submittedAddr, string depositedAddr, DateTime submittedOn)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SUBMITTEDADDR", submittedAddr),
                new SqlParameter("@DEPOSITADDR", depositedAddr),
                new SqlParameter("@STATUS", 1),
                new SqlParameter("@SUBMITTEDON",submittedOn),
            };

            ExecuteSPNonReturnData("InsertNewDepositAddress", parameters);
        }
        
        public void UpdateDepositAddress(SimpleSend submitaddr)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DEPOSITADDR", submitaddr.DepositAddress),
                new SqlParameter("@AMOUNT", submitaddr.Amount),
                new SqlParameter("@UPDATETIME", DateTime.Now),
                new SqlParameter("@STATUS", submitaddr.Status),
            };

            ExecuteSPNonReturnData("UpdateDepositAddress", parameters);
        }
    }
}