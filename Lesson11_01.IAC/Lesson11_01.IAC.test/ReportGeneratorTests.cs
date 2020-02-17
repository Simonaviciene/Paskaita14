using System;
using IAC.BL;
using IAC.BL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using IAC;

namespace Lesson11_01.IAC.test
{
    [TestClass]
    public class ReportGeneratorTests
    {
        [TestMethod]
        public void GenerateReportAircraftInEuropeShouldReturnListWithReportItems()
        {
            // Assign
            AircraftRepository aircraftRepository = new AircraftRepository();
            ReportGenerator reportGenerator = new ReportGenerator(
                aircraftRepository,
                new AircraftModelRepository(),
                new CompanyRepository(),
                new CountryRepository());

            // Act
            List<ReportItem> report = reportGenerator.GenerateReportAircraftInEurope();

            // Assert
            Assert.IsNotNull(report);
            Assert.IsTrue(report.Count > 0);
        }
        
    }
}
