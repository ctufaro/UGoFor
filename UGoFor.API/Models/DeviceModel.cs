using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UGoFor.API.DAL;

namespace UGoFor.API.Models
{
    public class DeviceModel
    {
        public int UserId { get; set; }
        public string DeviceId { get; set; }

        public void CheckDevice(DeviceModel device)
        {
            new DeviceDAL().CheckDevice(device);
        }
    }
}