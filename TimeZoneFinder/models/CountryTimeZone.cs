using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeZoneFinder.models
{
    public class CountryTimeZone
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string UTCTime { get; set; }
        public bool isDayLightSaving { get; set; }

        public static List<CountryTimeZone> countryTimeDiffernceList = new List<CountryTimeZone>()
        {
            new CountryTimeZone(){ Id = 1, Country="India", UTCTime="5:30", isDayLightSaving= false  },
            new CountryTimeZone(){ Id = 2, Country="US(CST)", UTCTime="-5:00", isDayLightSaving= true  },
            new CountryTimeZone(){ Id = 3, Country="US(CST)", UTCTime="-6:00", isDayLightSaving= false  },
             new CountryTimeZone(){ Id = 4, Country="US(EST)", UTCTime="-4:00", isDayLightSaving= true  },
            new CountryTimeZone(){ Id = 5, Country="US(EST)", UTCTime="-5:00", isDayLightSaving= false  },

        };
    }
}
