using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2019_BankSimulation.Models
{
    public class User : UserType
    {  
        public string firstName { get; set; }
        public string lastName { get; set; }

        public User()
        {

        }

        public User(string firstName, string lastName, decimal monthlyAmount)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.monthlyAmount = monthlyAmount;
            this.hasCredit = false;
            this.balance = 0;
        }

        public User(string firstName, string lastName, decimal monthlyAmount, decimal balance, bool hasCredit)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.monthlyAmount = monthlyAmount;
            this.hasCredit = hasCredit;
            this.balance = balance;
        }
    }
}
