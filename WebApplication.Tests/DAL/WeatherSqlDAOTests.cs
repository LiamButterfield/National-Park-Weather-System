using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Tests.DAL
{
    [TestClass]
    public class WeatherSqlDAOTests: NationalParksDAOTests
    {
        [TestMethod]
        public void SelectedPark_ReturnsDetails()
        {
            WeatherSqlDAO dao = new WeatherSqlDAO(ConnectionString);
            IList<Weather> weathers = dao.GetForecast("XYZ");
            Assert.AreEqual(5, weathers.Count);
        }

    }
}
