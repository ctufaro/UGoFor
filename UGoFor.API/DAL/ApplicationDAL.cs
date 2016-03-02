using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UGoFor.API.Models;

namespace UGoFor.API.DAL
{
    public class ApplicationDAL : BaseDAL
    {
        public ApplicationModel SelectApplicationSetting(int id)
        {
            List<ApplicationModel> applicationSettings = ExecuteSPReturnData<ApplicationModel>("SelectApplicationSetting");
            return applicationSettings.FirstOrDefault();
        }
    }
}