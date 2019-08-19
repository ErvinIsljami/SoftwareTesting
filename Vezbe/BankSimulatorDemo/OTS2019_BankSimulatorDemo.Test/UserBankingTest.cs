using NUnit.Framework;
using OTS2019_BankSimulation.Class;
using OTS2019_BankSimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2019_BankSimulatorDemo.Test
{
    [TestFixture]
    class UserBankingTest
    {
        [TestCase(1200, ExpectedResult = true)]
        public bool CashCreditSuccess(decimal amount)
        {
            User user = new User("Pera", "Peric", 1000, 1000, false);
            DateTime date = new DateTime(2021, 3, 20);
            OTS2019_BankSimulation.Form1.isChecked_rbtnCash = true;
            UserBanking ubanking = new UserBanking();
            return ubanking.Credit(user, amount, date);

          
        }

        [TestCase(300, 85, 10000, ExpectedResult = false)]
        public bool RevolvingSuccess(decimal monthlyAmount, decimal monthlyPayment, decimal amount)
        {
            User user2 = new User("Petar", "Pericic", monthlyAmount, monthlyPayment, false);
            DateTime date2 = new DateTime(2021, 3, 20);
            OTS2019_BankSimulation.Form1.isChecked_rbtnRevolving = true;
            UserBanking ubanking = new UserBanking();
            return ubanking.Credit(user2, amount, date2);
        }

    }
}
