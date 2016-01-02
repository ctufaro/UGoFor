using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UGoFor.API.DAL;
using System.Data;

namespace UGoFor.API.Models
{
    public class ActionModel : IFromDataReader<ActionModel>
    {
        public int? UserId { get; set; }
        public string Action { get; set; }
        public string Value { get; set; }

        public void PostAction(ActionModel sentAction)
        {
            if (sentAction.Equals("+Follow"))
            {
                new ActionDAL().InsertAction(sentAction);
            }
            else if (sentAction.Equals("Unfollow"))
            {
                new ActionDAL().DeleteAction(sentAction);
            }
        }

        public ActionModel FromDataReader(IDataReader dr)
        {
            ActionModel actionModel = new ActionModel();
            actionModel.UserId = dr["UserId"] is DBNull ? null : dr["UserId"] as Int32?;
            actionModel.Action = dr["Action"] is DBNull ? null : dr["Action"].ToString();
            actionModel.Value = dr["Value"] is DBNull ? null : dr["Value"].ToString();
            return actionModel;
        }
    }
}