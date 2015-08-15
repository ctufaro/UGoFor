using System;
using System.Collections.Generic;
using UGoFor.MVC.DAL;
using UGoFor.MVC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UGoFor.TEST
{
    [TestClass]
    public class TestDatabase
    {
        [TestMethod]
        public void Test_Select_All_Posts_Data_Table()
        {
            BaseDAL bDAL = new BaseDAL("Data Source=vm-dev-sql;Initial Catalog=SolrIndx; User Id=sa; Password=Professional2;Connection Timeout=6;");
            var retset = bDAL.ExecuteSPReturnDataTable("SelectAllUsersPosts");
            Assert.IsTrue(retset != null);
        }

        [TestMethod]
        public void Test_Select_All_Posts_Bind_To_Model()
        {
            PostsDAL pDAL = new PostsDAL("Data Source=vm-dev-sql;Initial Catalog=SolrIndx; User Id=sa; Password=Professional2;Connection Timeout=6;");
            List<PostsModel> postModels = pDAL.SelectAllUsersPosts();
            Assert.IsTrue(postModels != null);
        }
    }
}
