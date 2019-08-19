using OTS2019_ConvertorDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2019_ConvertorDemo
{
    public class MassConverter : IConvert
    {
        public double Convert(double input)
        {
            return input / 2.205;
        }
    }
}
