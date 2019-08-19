using OTS2019_ConvertorDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2019_ConvertorDemo
{
    public class LengthConverter : IConvert
    {
        public double Convert(double input)
        {
            return input / 3.281;
        }
    }
}
