using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Tests.DAL
{
    [TestClass]
    public class SurveySqlDAOTests : NationalParksDAOTests
    {
        [TestMethod]
        public void GetSurveyTest_ShouldReturnAllSurveys()
        {
            SurveySqlDAO dao = new SurveySqlDAO(ConnectionString);

            IList<SurveyResult> surveys = dao.Results();

            Assert.AreEqual(1, surveys.Count);
        }
    }
}
