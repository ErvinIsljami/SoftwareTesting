using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2019_ConvertorDemo.Test
{
    [TestFixture]
    class CustomMoneyConvertorTest
    {
        //Korišćenjem parametrizovanih testova takođe se može napisati metoda koja će testirati hvatanje nekog Exceptiona
        //Postavljeni Try-Catch blok u okviru klase CustomMoneyConvertor očekuje Exception tipa ArgumentNullException i taj tip Exceptiona i hvatamo u okviru testne metode na isti način kao i na primeru za MassConvertor
        [TestCase("$ to $")]
        public void Create_ExceptionFromUnexpectedInput(string input)
        {
            CustomMoneyConvertor moneyConvertor = new CustomMoneyConvertor(input);
            Assert.Throws<System.ArgumentNullException>(() => moneyConvertor.Convert(decimal.Parse(moneyConvertor.inputAmount)));
        }
    }
}
