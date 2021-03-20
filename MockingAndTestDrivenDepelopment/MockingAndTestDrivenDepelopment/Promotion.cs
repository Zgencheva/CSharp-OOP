using System;
using System.Collections.Generic;
using System.Text;

namespace MockingAndTestDrivenDepelopment
{
    public class Promotion
    {
        private DateTime dateToday;

        public Promotion(DateTime today)
        {
            dateToday = today;
        }

        public int Get()
        {
            if (dateToday.DayOfWeek == DayOfWeek.Monday)
            {
                return 30;
            }
            else if (dateToday.DayOfWeek == DayOfWeek.Tuesday)
            {
                return 10;
            }
            else if (dateToday.DayOfWeek == DayOfWeek.Wednesday)
            {
                return 40;
            }
            else if (dateToday.DayOfWeek == DayOfWeek.Sunday)
            {
                return -10;
            }
            else
            {
                return 0;
            }
        }
    }
}
