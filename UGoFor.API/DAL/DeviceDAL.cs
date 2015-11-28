using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UGoFor.API.Models;

namespace UGoFor.API.DAL
{
    public class DeviceDAL : BaseDAL
    {
        public void CheckDevice(DeviceModel device)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
              new SqlParameter("@USERID", device.UserId),
              new SqlParameter("@DEVICEID", device.DeviceId),
            };

            ExecuteSPNonReturnData("UpdateUserDevice", parameters);    

        }
    }
}