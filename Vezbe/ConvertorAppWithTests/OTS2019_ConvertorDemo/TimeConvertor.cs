using OTS2019_ConvertorDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2019_ConvertorDemo
{
    public class TimeConvertor : ITimeConvertor
    {
        public int DaysToHours(int days)
        {
            return days * 24;
        }

        public int DaysToMinutes(int days)
        {
            return days * 24 * 60;
        }

        public int DaysToSeconds(int days)
        {
            return days * 24 * 60 * 60;
        }
    }
}
