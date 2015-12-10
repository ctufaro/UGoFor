using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UGoFor.API.DAL;

namespace UGoFor.API.Models
{
    public class CraveModel
    {
        public int UserId { get; set; }
        public int Type { get; set; }
        public int? PostId { get; set; }
        public string CravingTextShort { get; set; }
        public string CravingTextLong { get; set; }
        public string CravingPic { get; set; }
        public string TimePosted { get; set; }
        public string Location { get; set; }

        public void InsertCrave(CraveModel crave)
        {
            new CraveDAL().InsertCrave(crave);
        }
    }
}