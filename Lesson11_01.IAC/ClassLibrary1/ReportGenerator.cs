using IAC.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IAC.BL
{
    public class ReportGenerator
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
        public List<ReportItem> GenerateReportAircraftInEurope()
       {
            List<ReportItem> reportItems = new List<ReportItem>();

            foreach (var lektuvas in aircraftRepository.Retrieve())
            {
                Company company = companyRepository.Retrieve(lektuvas.CompanyId);
                Country country = countryRepository.Retrieve(company.CountryId);
                
                if(country.Continent == "Europe" )
                {
                    AircraftModel aircraftModel = aircraftModelRepository.Retrieve(lektuvas.ModelId);
                    ReportItem reportItem = CreateReportItem(lektuvas, company, country, aircraftModel);

                    reportItems.Add(reportItem);
                }
            }
           
            return reportItems;
       }
        public List<ReportItem> GenerateReportAircraftNotInEurope()
        {
            List<ReportItem> reportItems = new List<ReportItem>();

            foreach (var lektuvas in aircraftRepository.Retrieve())
            {
                Company company = companyRepository.Retrieve(lektuvas.CompanyId);
                Country country = countryRepository.Retrieve(company.CountryId);

                if (country.Continent != "Europe")
                {
                    AircraftModel aircraftModel = aircraftModelRepository.Retrieve(lektuvas.ModelId);
                    ReportItem reportItem = CreateReportItem(lektuvas, company, country, aircraftModel);

                    reportItems.Add(reportItem);
                }
            }

            return reportItems;
        }

        private static ReportItem CreateReportItem(Aircraft lektuvas, Company company, Country country, AircraftModel aircraftModel)
        {
            ReportItem reportItem = new ReportItem();
            reportItem.AircraftTailNumber = lektuvas.TailNumber;
            reportItem.BelongsToEU = country.BelongsToEU;
            reportItem.CompanyCountryCode = country.Code;
            reportItem.CompanyCountryName = country.Name;
            reportItem.ModelDescription = aircraftModel.Description;
            reportItem.ModelNumber = aircraftModel.Number;
            reportItem.OwnerCompanyName = company.Name;
            return reportItem;
        }
    }
}
