using NUnit.Framework;
using OTS2019_ConvertorDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2019_Convertor_StudentsDemo.Test
{
    [TestFixture]
    class LenghtConverterTest
    {
        [Test]
        public void LengthConvert_TestSuccess()
        {
            LengthConverter length = new LengthConverter();
            double result = length.Convert(500);//pass sta da testiramo
            Assert.AreNotEqual(320.443, result, "FOr test true assert is true:", null);
        }
    }
}
