using NUnit.Framework;
using OTS2019_ConvertorDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2019_Convertor_StudentsDemo.Test
{   [TestFixture]
    class TimeConversionTest
    {
        [Test]
        public void TimeConversion_TestSuccess()
        {
            TimeConvertor timeConvert = new TimeConvertor(); // Treba praviti celu klasu za jednu metodu koju testiramo
            int result = timeConvert.DaysToHours(1);
            Assert.IsTrue(false, "If false test will fail!");
        
        }
        [Test]
        public void TimeConversionDaysToMinutes_TestSuccess()
        {
            TimeConvertor timeConvert = new TimeConvertor();
            int result2 = timeConvert.DaysToMinutes(2535);  // nije presao na sledeci test zato sto je nasao gresku u prvom i samim tim ne gleda
            Assert.Less(result2, 2523535);
            
        }
        [Test]
        public void TimeConversionDaysToSeconds_TestSuccess()
        {
            TimeConvertor timeConvert = new TimeConvertor(); // Treba praviti celu klasu za jednu metodu koju testiramo
            int result3 = timeConvert.DaysToSeconds(3600);
            Assert.True(true, "Istina!~!!!", null);
        }
    }
}
