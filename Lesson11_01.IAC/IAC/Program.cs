using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using IAC.BL;
using IAC.BL.Repositories;

namespace IAC
{
    class Program
    {
        static void Main(string[] args)
        {
            AircraftRepository aircraftRepository = new AircraftRepository();
            ReportGenerator reportGenerator = new ReportGenerator(
                aircraftRepository,
                new AircraftModelRepository(),
                new CompanyRepository(),
                new CountryRepository());

            List<ReportItem> ataskaita = reportGenerator.GenerateReportAircraftInEurope();
            HTMLFormatter hTMLFormatter = new HTMLFormatter();
            string hTMLPuslapis = hTMLFormatter.FormatHTML(ataskaita);

            List<ReportItem> ataskaita1 = reportGenerator.GenerateReportAircraftInEurope();
            HTMLFormatter hTMLFormatter1 = new HTMLFormatter();
            string hTMLPuslapis1 = hTMLFormatter1.FormatHTML(ataskaita1);

            Console.WriteLine("{0}", hTMLPuslapis);

            var client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("b2cbc79692a06d", "dd6c21035ef601"),
                EnableSsl = true
            };
            var msg = new MailMessage(
                "from@gmail.com",
                "to@gmail.com",
                "HTML Report",
                hTMLPuslapis);

            msg.IsBodyHtml = true;

           // client.Send(msg);
            Console.WriteLine("Sent");

            foreach (var item in reportGenerator.GenerateReportAircraftInEurope())
            {
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}",
                    item.CompanyCountryCode,
                    item.AircraftTailNumber,
                    item.BelongsToEU,
                    item.CompanyCountryName,
                    item.ModelDescription,
                    item.ModelNumber,
                    item.OwnerCompanyName);

            }
            Console.ReadLine();
        }
    }
}
