using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Tests.DAL
{
    [TestClass]
    public class ParkSqlDAOTests : NationalParksDAOTests
    {
        [TestMethod]
        public void GetParkTest_ShouldReturnAllParks()
        {
            ParkSqlDAO dao = new ParkSqlDAO(ConnectionString);

            IList<Park> parks = dao.GetAllParks();

            Assert.AreEqual(1, parks.Count);
        }
    }
}
