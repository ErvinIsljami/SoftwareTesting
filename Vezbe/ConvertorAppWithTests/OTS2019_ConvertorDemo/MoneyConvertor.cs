using OTS2019_ConvertorDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2019_ConvertorDemo
{
    public class MoneyConvertor : IMoneyConvertor
    {
        public decimal Convert(decimal input)
        {
            return input * 118.021972M;
        }
    }
}
