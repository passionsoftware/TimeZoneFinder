using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeZoneFinder.models
{
   public class CountryList
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Photo { get; set; }
        public TimeZoneInfo TimeZone { get; set; }

        public static List<CountryList> countryList = new List<CountryList>()
        {
            new CountryList() {ID = 1, Name = "India", Photo = "../assets/india.png", TimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time") },
            new CountryList() {ID = 2, Name = "US(CST)", Photo = "../assets/US.png", TimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time") },
            new CountryList() {ID = 3, Name = "US(EST)", Photo = "../assets/US.png", TimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time") },
        };

    }
}
