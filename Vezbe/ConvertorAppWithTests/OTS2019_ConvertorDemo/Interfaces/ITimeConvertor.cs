using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2019_ConvertorDemo.Interfaces
{
    public interface ITimeConvertor
    {
        int DaysToHours(int days);

        int DaysToMinutes(int days);

        int DaysToSeconds(int days);
    }
}
