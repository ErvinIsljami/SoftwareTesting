using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2019_BankSimulation.Models
{
    public class Company : UserType
    {
        public string name;

        public Company ()
        {

        }

        public Company (string name, decimal monthlyAmount)
        {
            this.name = name;
            this.monthlyAmount = monthlyAmount;
            this.balance = 0;
            this.hasCredit = false;
        }

        public Company (string name, decimal monthlyAmount, decimal balance, bool hasCredit)
        {
            this.name = name;
            this.monthlyAmount = monthlyAmount;
            this.balance = balance;
            this.hasCredit = hasCredit;
        }
    }
}
