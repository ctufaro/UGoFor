using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UGoFor.API.DAL;
using System.Data;

namespace UGoFor.API.Models
{
    public class ApplicationModel : IFromDataReader<ApplicationModel>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public ApplicationModel FromDataReader(IDataReader dr)
        {
            ApplicationModel applicationModel = new ApplicationModel();
            applicationModel.Id = dr["Id"] is DBNull ? null : dr["Id"] as Int32?;
            applicationModel.Name = dr["Name"] is DBNull ? null : dr["Name"].ToString();
            applicationModel.Value = dr["Value"] is DBNull ? null : dr["Value"].ToString();
            return applicationModel;
        }

        public ApplicationModel SelectApplicationSetting(int id)
        {
            return new ApplicationDAL().SelectApplicationSetting(id);
        }
    }
}