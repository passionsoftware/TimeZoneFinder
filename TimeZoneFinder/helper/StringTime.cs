using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeZoneFinder.helper
{
    public class StringTime
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public bool IsAfterNoon { get; set; }

        public StringTime(string timeString)
        {
            IsAfterNoon = timeString.Contains("pm");
            timeString = timeString.Replace("pm", "").Replace("am", "").Trim();

            Hours = int.Parse(timeString.Split(':')[0]);
            Minutes = int.Parse(timeString.Split(':')[1]);

        }

        public TimeSpan TotimeSpan()
        {
            if(IsAfterNoon)
            {
                if(Hours < 12)
                {
                    Hours += 12;
                }
            }
            return new TimeSpan(Hours, Minutes, 00);
        }

        public TimeSpan Add(StringTime time2)
        {
            return this.TotimeSpan().Add(time2.TotimeSpan());
        }

        public TimeSpan Subtract(StringTime time2)
        {
            return this.TotimeSpan().Subtract(time2.TotimeSpan());
        }

    }
}
