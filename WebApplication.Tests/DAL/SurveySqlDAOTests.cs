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

        [TestMethod]
        public void AddSurvey_should_IncreaseCountBy1()
        {
            SurveySqlDAO dao = new SurveySqlDAO(ConnectionString);
            int initalRowCount = GetRowCount("survey_result");

            Survey sur = new Survey()
            {
                ParkCode = "XYZ",
                EmailAddress = "test1@email.com",
                State = "Ohio",
                ActivityLevel = "Inactive",
    
            };

            dao.CreateSurvey(sur);

            int finalRowCount = GetRowCount("survey_result");
            Assert.AreEqual(initalRowCount + 1, finalRowCount);
        }
    }
}
