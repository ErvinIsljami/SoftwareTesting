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
    class MassConvertorTest
    {
        [Test]
        // Testovi ce biti metode koje testiraju metode iz samog core projekta
        // najosnovniji testovi ce biti bez return statmenta tj bice void
        // naziv testa treba da bude jasan za onoga koji nije pisao program
        public void Convert_TestSuccess()
        {
            MassConverter mass = new MassConverter();
            double result = mass.Convert(10);
            Assert.AreEqual(4.5351473922902494d, result);
        }
        [Test]
        public void Convert_CatchException()
        {
            MassConverter mass = new MassConverter();
            Assert.Throws<System.FormatException>(() => mass.Convert(double.Parse(""))); // prvi deo metode preambula deo uslov koji sprecava omogucavnanje metode
        }  // primer passovanja nule ili range izvan double tipa


          [TestCase(10, 4.5351473922902494d)] // Parametarski testovi!!!
          [TestCase(0,0)] // jos jedan test case omogucava nam da pozivamo dva razlicita testa nad istom jednom metodom!
         public void Convert_TestSuccessParams(int input, double result)
        {
            MassConverter mass = new MassConverter();
            double value = mass.Convert(input);
            Assert.AreEqual(result, value);

        }


        // Druga vrsta Params testova je sa return statementima
        // VisualStudio prepoznaje po ExpectedResult = izjavom da je param test sa return statmentom
        [TestCase(10, ExpectedResult = 4.5351473922902494d)]
        [TestCase(0, 0)] // opet za jednu metodu moze isto vise testova
        public double Convert_TestSuccessParamsWithReturnStatment(int input)
        {
            MassConverter mass = new MassConverter();
            return mass.Convert(input);
        }
    }
}
