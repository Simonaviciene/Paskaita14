using IAC.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IAC.BL
{
    class ReportGenerator
    {
        private AircraftRepository aircraftRepository;
        private AircraftModelRepository aircraftModelRepository;
        private CompanyRepository companyRepository;
        private CountryRepository countryRepository;

        public ReportGenerator(AircraftRepository aircraftRepository, AircraftModelRepository aircraftModelRepository, CompanyRepository companyRepository, CountryRepository countryRepository)
        {
            this.aircraftRepository = aircraftRepository;
            this.aircraftModelRepository = aircraftModelRepository;
            this.companyRepository = companyRepository;
            this.countryRepository = countryRepository;
        }
       // public List<ReportItem> GenerateReportAircraftInEurope()
       // {
           // List<ReportItem> 
       // }
    }
}
